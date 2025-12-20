//-----------------------------------------------------------
// Ben Ebadinia
// Java++ Compiler
// Java++Compiler.cpp
//-----------------------------------------------------------
#include <iostream>
#include <iomanip>

#include <fstream>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <cctype>
#include <vector>

using namespace std;

//#define TRACEREADER
//#define TRACESCANNER
//#define TRACEPARSER
//#define TRACEIDENTIFIERTABLE
//#define TRACECOMPILER

#include "Java++.h"

//-----------------------------------------------------------
typedef enum
//-----------------------------------------------------------
{
// pseudo-terminals
   VID,
   INT,
   STRING,
   EOPTOKEN,
   UNKTOKEN,
// reserved words
   START,
   FIN,
   COUT,
   COUTLN,
   OR,
   NOR,
   XOR,
   AND,
   NAND,
   NOT,
   ABSOLUTE,
   TRUE,
   FALSE,
   VARIABLE,
   NUM,
   BOOLEAN,
   FINAL,
   STDIN,
   IF,
   EXECUTE,
   OTHERWISEIF,
   OTHERWISE,
   REPEAT,
   WHILE,
// punctuation
   SEMICOLON,
   PERIOD,
   OPEN,
   CLOSE,
   OBRACKET,
   CBRACKET,
   INTO,
   OBRACE,
   CBRACE,
// operators
   LESSER,
   LESSEREQUAL,
   EQUAL,
   GREATER,
   GREATEREQUAL,
   NOTEQUAL,
   ADDITION,
   SUBTRACTION,
   MULTIPLICATION,
   DIVISION,
   MODULUS,
   POWER,
   INCREMENT,
   DECREMENT
} TOKENTYPE;

//-----------------------------------------------------------
struct TOKENTABLERECORD
//-----------------------------------------------------------
{
   TOKENTYPE type;
   char description[15+1];
   bool isReservedWord;
};

//-----------------------------------------------------------
const TOKENTABLERECORD TOKENTABLE[] =
//-----------------------------------------------------------
{
   { VID 		 	,"VID"  			,false },
   { INT	     	,"INT"		    	,false },
   { STRING      	,"STRING"      		,false },
   { EOPTOKEN    	,"EOPTOKEN"    		,false },
   { UNKTOKEN    	,"UNKTOKEN"    		,false },
   { START	     	,"START" 	    	,true  },
   { FIN         	,"FIN"         		,true  },
   { COUT		 	,"cout"        		,true  },
   { COUTLN      	,"coutln"      		,true  },
   { OR          	,"OR"          		,true  },
   { NOR         	,"NOR"         		,true  },
   { XOR         	,"XOR"         		,true  },
   { AND         	,"AND"         		,true  },
   { NAND        	,"NAND"        		,true  },
   { NOT         	,"NOT"         		,true  },
   { ABSOLUTE    	,"ABSOLUTE"    		,true  },
   { TRUE        	,"TRUE"        		,true  },
   { FALSE       	,"FALSE"       		,true  },
   { VARIABLE       ,"VARIABLE"    		,true  },
   { NUM         	,"NUM"		        ,true  },
   { BOOLEAN        ,"BOOLEAN"	        ,true  },
   { FINAL          ,"FINAL"            ,true  },
   { STDIN	        ,"STDIN" 	        ,true  },
   { IF             ,"IF"               ,true  },
   { EXECUTE        ,"EXECUTE"          ,true  },
   { OTHERWISEIF    ,"OTHERWISEIF"      ,true  },
   { OTHERWISE      ,"OTHERWISE"        ,true  },
   { REPEAT         ,"REPEAT"           ,true  },
   { WHILE          ,"WHILE"            ,true  },
   { SEMICOLON      ,"SEMICOLON"       	,false },
   { PERIOD      	,"PERIOD"      		,false },
   { OPEN        	,"OPEN"        		,false },
   { CLOSE       	,"CLOSE"       		,false },
   { OBRACKET    	,"OBRACKET"     	,false },
   { CBRACKET       ,"CBRACKET"       	,false },
   { OBRACE     	,"OBRACE"       	,false },
   { CBRACE         ,"CBRACE"       	,false },
   { INTO	        ,"INTO"         	,false },
   { LESSER      	,"LESSER"      		,false },
   { LESSEREQUAL 	,"LESSEREQUAL" 		,false },
   { EQUAL       	,"EQUAL"       		,false },
   { GREATER     	,"GREATER"     		,false },
   { GREATEREQUAL	,"GREATEREQUAL"		,false },
   { NOTEQUAL    	,"NOTEQUAL"    		,false },
   { ADDITION    	,"ADDITION"    		,false },
   { SUBTRACTION 	,"SUBTRACTION" 		,false },
   { MULTIPLICATION ,"MULTIPLICATION"   ,false },
   { DIVISION  		,"DIVISION"      	,false },
   { MODULUS     	,"MODULUS"     		,false },
   { POWER       	,"POWER"       		,false },
   { INCREMENT      ,"INCREMENT"        ,false },
   { DECREMENT      ,"DECREMENT"        ,false }
};

//-----------------------------------------------------------
struct TOKEN
//-----------------------------------------------------------
{
   TOKENTYPE type;
   char lexeme[SOURCELINELENGTH+1];
   int sourceLineNumber;
   int sourceLineIndex;
};

//--------------------------------------------------
// Global variables
//--------------------------------------------------
READER<CALLBACKSUSED> reader(SOURCELINELENGTH,LOOKAHEAD);
LISTER lister(LINESPERPAGE);
// CODEGENERATION
CODE code;
IDENTIFIERTABLE identifierTable(&lister,MAXIMUMIDENTIFIERS);
// ENDCODEGENERATION

#ifdef TRACEPARSER
int level;
#endif

//-----------------------------------------------------------
void EnterModule(const char module[])
//-----------------------------------------------------------
{
#ifdef TRACEPARSER
   char information[SOURCELINELENGTH+1];

   level++;
   sprintf(information,"   %*s>%s",level*2," ",module);
   lister.ListInformationLine(information);
#endif
}

//-----------------------------------------------------------
void ExitModule(const char module[])
//-----------------------------------------------------------
{
#ifdef TRACEPARSER
   char information[SOURCELINELENGTH+1];

   sprintf(information,"   %*s<%s",level*2," ",module);
   lister.ListInformationLine(information);
   level--;
#endif
}

//--------------------------------------------------
void ProcessCompilerError(int sourceLineNumber,int sourceLineIndex,const char errorMessage[])
//--------------------------------------------------
{
   char information[SOURCELINELENGTH+1];

// Use "panic mode" error recovery technique: report error message and terminate compilation!
   sprintf(information,"     At (%4d:%3d) %s",sourceLineNumber,sourceLineIndex,errorMessage);
   lister.ListInformationLine(information);
   lister.ListInformationLine("Java++ compiler ending with compiler error!\n");
   throw( JAVAPLUSEXCEPTION("Java++ compiler ending with compiler error!") );
}

//-----------------------------------------------------------
int main()
//-----------------------------------------------------------
{
   void Callback1(int sourceLineNumber,const char sourceLine[]);
   void Callback2(int sourceLineNumber,const char sourceLine[]);
   void GetNextToken(TOKEN tokens[]);
   void ParseJAVAPLUSProgram(TOKEN tokens[]);

   char sourceFileName[80+1];
   TOKEN tokens[LOOKAHEAD+1];
   
   cout << "Source filename? ";
   cin >> sourceFileName;

   try
   {
      lister.OpenFile(sourceFileName);
      code.OpenFile(sourceFileName);

// CODEGENERATION
      code.EmitBeginningCode(sourceFileName);
// ENDCODEGENERATION
      
      reader.SetLister(&lister);
      reader.AddCallbackFunction(Callback1);
      reader.AddCallbackFunction(Callback2);
      reader.OpenFile(sourceFileName);

   // Fill tokens[] for look-ahead
      for (int i = 0; i <= LOOKAHEAD; i++)
         GetNextToken(tokens);

#ifdef TRACEPARSER
      level = 0;
#endif
   
      ParseJAVAPLUSProgram(tokens);
      
// CODEGENERATION
      code.EmitEndingCode();
// ENDCODEGENERATION
      
   }
   catch (JAVAPLUSEXCEPTION javaplusException)
   {
      cout << "Java++ exception: " << javaplusException.GetDescription() << endl;
   }
   lister.ListInformationLine("******* Java++ Compiler ending");
   cout << "Java++ compiler ending\n";

   system("PAUSE");
   return( 0 );
   
}

//-----------------------------------------------------------
void ParseJAVAPLUSProgram(TOKEN tokens[])
//-----------------------------------------------------------
{
   void GetNextToken(TOKEN tokens[]);
   void ParseSTARTDefinition(TOKEN tokens[]);

   EnterModule("Java++Program");

   if ( tokens[0].type == START )
      ParseSTARTDefinition(tokens);
   else
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting START");

   if ( tokens[0].type != EOPTOKEN )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting end-of-program");

   ExitModule("Java++Program");
}

//-----------------------------------------------------------
void ParseSTARTDefinition(TOKEN tokens[])
//-----------------------------------------------------------
{
   void ParseDataDefinitions(TOKEN tokens[],IDENTIFIERSCOPE identifierScope);
   void GetNextToken(TOKEN tokens[]);
   void ParseStatement(TOKEN tokens[]);
   
   char line[SOURCELINELENGTH+1];
   char label[SOURCELINELENGTH+1];
   char reference[SOURCELINELENGTH+1];

   EnterModule("STARTDefinition");
   
// CODEGENERATION
   code.EmitUnformattedLine("** ==============");
   sprintf(line,"**      START module (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);
   code.EmitUnformattedLine("** ==============");
   code.EmitFormattedLine("STARTMAIN","EQU"  ,"*");

   code.EmitFormattedLine("","PUSH" ,"#RUNTIMESTACK","set SP");
   code.EmitFormattedLine("","POPSP");
   code.EmitFormattedLine("","PUSHA","STATICDATA","set SB");
   code.EmitFormattedLine("","POPSB");
   code.EmitFormattedLine("","PUSH","#HEAPBASE","initialize heap");
   code.EmitFormattedLine("","PUSH","#HEAPSIZE");
   code.EmitFormattedLine("","SVC","#SVC_INITIALIZE_HEAP");
   sprintf(label,"STARTBODY%04d",code.LabelSuffix());
   code.EmitFormattedLine("","CALL",label);
   code.AddDSToStaticData("Normal program termination","",reference);
   code.EmitFormattedLine("","PUSHA",reference);
   code.EmitFormattedLine("","SVC","#SVC_WRITE_STRING");
   code.EmitFormattedLine("","SVC","#SVC_WRITE_ENDL");
   code.EmitFormattedLine("","PUSH","#0D0","terminate with status = 0");
   code.EmitFormattedLine("","SVC" ,"#SVC_TERMINATE");
   code.EmitUnformattedLine("");
   code.EmitFormattedLine(label,"EQU","*");
// ENDCODEGENERATION

   GetNextToken(tokens);
   
   identifierTable.EnterNestedStaticScope();
   ParseDataDefinitions(tokens,PROGRAMMODULESCOPE);

   while ( tokens[0].type != FIN )
      ParseStatement(tokens);
      
// CODEGENERATION
   code.EmitFormattedLine("","RETURN");
   code.EmitUnformattedLine("** ==============");
   sprintf(line,"**      FIN (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);
   code.EmitUnformattedLine("** ==============");
// ENDCODEGENERATION

#ifdef TRACECOMPILER
   identifierTable.DisplayTableContents("Contents of identifier table at end of compilation of START module definition");
#endif

   identifierTable.ExitNestedStaticScope();
	
   GetNextToken(tokens);

   ExitModule("STARTDefinition");
}

//-----------------------------------------------------------
void ParseDataDefinitions(TOKEN tokens[],IDENTIFIERSCOPE identifierScope)
//-----------------------------------------------------------
{
   void GetNextToken(TOKEN tokens[]);

   EnterModule("DataDefinitions");

   while ( (tokens[0].type == VARIABLE) || (tokens[0].type == FINAL) )
   {
      switch ( tokens[0].type )
      {
         case VARIABLE:
            do
            {
               char literal[MAXIMUMLENGTHIDENTIFIER+1];
               char vid[MAXIMUMLENGTHIDENTIFIER+1];
               char reference[MAXIMUMLENGTHIDENTIFIER+1];
               DATATYPE datatype;
               bool isInTable;
               int index;
      
               GetNextToken(tokens);
         
               switch ( tokens[0].type )
               {
                  case NUM:
                     datatype = INTEGERTYPE;
                     break;
                  case BOOLEAN:
                     datatype = BOOLEANTYPE;
                     break;
                  default:
                     ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting NUM or BOOLEAN");
               }
               GetNextToken(tokens);
               
               if ( tokens[0].type != VID )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting identifier");
               strcpy(vid,tokens[0].lexeme);
               GetNextToken(tokens);
               
               if ( tokens[0].type == INTO )
               {
			   		GetNextToken(tokens);
         
               		if ( (datatype == INTEGERTYPE) && (tokens[0].type == INT) )
               		{
                  		strcpy(literal,"0D");
                  		strcat(literal,tokens[0].lexeme);
               		}
               		else if ( ((datatype == BOOLEANTYPE) && (tokens[0].type == TRUE)) || ((datatype == BOOLEANTYPE) && (tokens[0].type == FALSE)) )
                 		strcpy(literal,tokens[0].lexeme);
               		else
                  		ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Data type mismatch");
               		GetNextToken(tokens);
               		
               		index = identifierTable.GetIndex(vid,isInTable);
               		if ( isInTable && identifierTable.IsInCurrentScope(index) )
                  		ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Multiply-defined identifier");

// CODEGENERATION
                     code.AddDWToStaticData(literal,vid,reference);
// ENDCODEGENERATION
                     identifierTable.AddToTable(vid,PROGRAMMODULE_VARIABLE,datatype,reference);
           	   }
         	   else
         	   {
					index = identifierTable.GetIndex(vid,isInTable);
               		if ( isInTable && identifierTable.IsInCurrentScope(index) )
                  		ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Multiply-defined identifier");
      		   
// CODEGENERATION
                	code.AddRWToStaticData(1,vid,reference);
// ENDCODEGENERATION
                	identifierTable.AddToTable(vid,PROGRAMMODULE_VARIABLE,datatype,reference);
			   }


            } while ( tokens[0].type == SEMICOLON );
      
            if ( tokens[0].type != PERIOD )
               ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '.'");
            GetNextToken(tokens);
            break;
            
         case FINAL:
            do
            {
               char vid[MAXIMUMLENGTHIDENTIFIER+1];
               char literal[MAXIMUMLENGTHIDENTIFIER+1];
               char reference[MAXIMUMLENGTHIDENTIFIER+1];
               DATATYPE datatype;
               bool isInTable;
               int index;
      
               GetNextToken(tokens);
         
               switch ( tokens[0].type )
               {
                  case NUM:
                     datatype = INTEGERTYPE;
                     break;
                  case BOOLEAN:
                     datatype = BOOLEANTYPE;
                     break;
                  default:
                     ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting NUM or BOOLEAN");
               }
               GetNextToken(tokens);
               
               if ( tokens[0].type != VID )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting identifier");
               strcpy(vid,tokens[0].lexeme);
               GetNextToken(tokens);
         
               if ( tokens[0].type != INTO )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '<<'");
               GetNextToken(tokens);
         
               if      ( (datatype == INTEGERTYPE) && (tokens[0].type == INT) )
               {
                  strcpy(literal,"0D");
                  strcat(literal,tokens[0].lexeme);
               }
               else if ( ((datatype == BOOLEANTYPE) && (tokens[0].type == TRUE)) || ((datatype == BOOLEANTYPE) && (tokens[0].type == FALSE)) )
                 strcpy(literal,tokens[0].lexeme);
               else
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Data type mismatch");
               GetNextToken(tokens);
          
               index = identifierTable.GetIndex(vid,isInTable);
               if ( isInTable && identifierTable.IsInCurrentScope(index) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Multiply-defined identifier");

// CODEGENERATION
                     code.AddDWToStaticData(literal,vid,reference);
// ENDCODEGENERATION
                     identifierTable.AddToTable(vid,PROGRAMMODULE_CONSTANT,datatype,reference);

            } while ( tokens[0].type == SEMICOLON );
      
            if ( tokens[0].type != PERIOD )
               ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '.'");
            GetNextToken(tokens);
            break;
       }
   }

   ExitModule("DataDefinitions");

}

//-----------------------------------------------------------
void ParseStatement(TOKEN tokens[])
//-----------------------------------------------------------
{
   void GetNextToken(TOKEN tokens[]);
   void ParseSTDINStatement(TOKEN tokens[]);
   void ParseAssignmentStatement(TOKEN tokens[]);
   void ParseEITHERStatement(TOKEN tokens[], bool isLN);
   void ParseIFStatement(TOKEN tokens[]);
   void ParseREPEATWHILEStatement(TOKEN tokens[]);

   EnterModule("Statement");

   switch ( tokens[0].type )
   {
      case COUT:
         ParseEITHERStatement(tokens, false);
         break;
      case COUTLN:
         ParseEITHERStatement(tokens, true);
         break;
      case STDIN:
         ParseSTDINStatement(tokens);
         break;
      case VARIABLE:
         ParseDataDefinitions(tokens,PROGRAMMODULESCOPE);
         break;
      case VID:
         ParseAssignmentStatement(tokens);
         break;
      case IF:
         ParseIFStatement(tokens);
         break;
      case REPEAT:
         ParseREPEATWHILEStatement(tokens);
         break;
      default:
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting beginning-of-statement");
         break;
   }

   ExitModule("Statement");
}

//-----------------------------------------------------------
void ParseEITHERStatement(TOKEN tokens[], bool isLN)
//-----------------------------------------------------------
{
   void ParseORExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);
   
   char line[SOURCELINELENGTH+1];
   DATATYPE datatype;
   
   (isLN == true) ? EnterModule("COUTLNStatement") : EnterModule("COUTStatement"); // First Check if is cout or coutln


   if (isLN == true)
   {
// CODEGENERATION
   	sprintf(line,"**      COUTLN statement (%4d)",tokens[0].sourceLineNumber);
   	code.EmitUnformattedLine(line);
// ENDCODEGENERATION
   }
   else
   {
// CODEGENERATION
   	sprintf(line,"**      COUT statement (%4d)",tokens[0].sourceLineNumber);
   	code.EmitUnformattedLine(line);
// ENDCODEGENERATION
   }
	GetNextToken(tokens);
	
	if ( tokens[0].type != OPEN )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting '('");
	
	GetNextToken(tokens);
	
   if( tokens[0].type != CLOSE )
   {  
	    do
	    {
      		switch ( tokens[0].type )
      		{
         		case STRING:
         			
// CODEGENERATION
            		char reference[SOURCELINELENGTH+1];

            		code.AddDSToStaticData(tokens[0].lexeme,"",reference);
            		code.EmitFormattedLine("","PUSHA",reference);
            		code.EmitFormattedLine("","SVC","#SVC_WRITE_STRING");
// ENDCODEGENERATION

            		GetNextToken(tokens);
            		if(tokens[0].type == SEMICOLON)
            		{
            			GetNextToken(tokens);
					}
					else if (tokens[0].type != CLOSE)
					{
						ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting ;");
					}
            		break;

         		default:
         		{
         			ParseORExpression(tokens,datatype);
         			
// CODEGENERATION
            		switch ( datatype )
            		{
               			case INTEGERTYPE:
                  			code.EmitFormattedLine("","SVC","#SVC_WRITE_INTEGER");
                  			break;
               			case BOOLEANTYPE:
                  			code.EmitFormattedLine("","SVC","#SVC_WRITE_BOOLEAN");
                  			break;
            		}
// ENDCODEGENERATION

            		if(tokens[0].type == SEMICOLON)
            		{
            			GetNextToken(tokens);
					}
					else if (tokens[0].type != CLOSE)
					{
						ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting ;");
					}
            		break;

            	}
       		}
    	} while  (tokens[0].type != CLOSE);
   } 
   
   GetNextToken(tokens);

   if ( tokens[0].type != PERIOD )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex, "Expecting '.'");

   GetNextToken(tokens);
   
   if(isLN == true)
   {
// CODEGENERATION
            code.EmitFormattedLine("","SVC","#SVC_WRITE_ENDL");
// ENDCODEGENERATION
   }

   (isLN == true) ? ExitModule("COUTLNStatement") : ExitModule("COUTStatement"); // Second Check if is cout or coutln
}

//-----------------------------------------------------------
void ParseSTDINStatement(TOKEN tokens[])
//-----------------------------------------------------------
{
   void ParseVID(TOKEN tokens[],bool asLValue,DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   char reference[SOURCELINELENGTH+1];
   char line[SOURCELINELENGTH+1];
   DATATYPE datatype;

   EnterModule("STDINStatement");

   sprintf(line,"** **** STDIN statement (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);

   GetNextToken(tokens);

   if ( tokens[0].type == STRING )
   {

// CODEGENERATION
      code.AddDSToStaticData(tokens[0].lexeme,"",reference);
      code.EmitFormattedLine("","PUSHA",reference);
      code.EmitFormattedLine("","SVC","#SVC_WRITE_STRING");
// ENDCODEGENERATION

      GetNextToken(tokens);
   }

   if ( tokens[0].type != SEMICOLON )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting ';'");
   GetNextToken(tokens);
      
   ParseVID(tokens,true,datatype);

// CODEGENERATION
   switch ( datatype )
   {
      case INTEGERTYPE:
         code.EmitFormattedLine("","SVC","#SVC_READ_INTEGER");
         break;
      case BOOLEANTYPE:
         code.EmitFormattedLine("","SVC","#SVC_READ_BOOLEAN");
         break;
   }
   code.EmitFormattedLine("","POP","@SP:0D1");
   code.EmitFormattedLine("","DISCARD","#0D1");
// ENDCODEGENERATION

   if ( tokens[0].type != PERIOD )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '.'");

   GetNextToken(tokens);

   ExitModule("STDINStatement");
}

//-----------------------------------------------------------
void ParseAssignmentStatement(TOKEN tokens[])
//-----------------------------------------------------------
{
   void ParseVID(TOKEN tokens[],bool asLValue,DATATYPE &datatype);
   void ParseORExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   char line[SOURCELINELENGTH+1];
   DATATYPE datatypeLHS,datatypeRHS;
   int n;

   EnterModule("AssignmentStatement");

   sprintf(line,"** **** assignment statement (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);

   ParseVID(tokens,true,datatypeLHS);
   n = 1;

   while ( tokens[0].type == SEMICOLON )
   {
      DATATYPE datatype;

      GetNextToken(tokens);
      ParseVID(tokens,true,datatype);
      n++;

      if ( datatype != datatypeLHS )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Mixed-mode variables not allowed");
   }
   if ( tokens[0].type != INTO )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '<<'");
   GetNextToken(tokens);

   ParseORExpression(tokens,datatypeRHS);

   if ( datatypeLHS != datatypeRHS )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Data type mismatch");

// CODEGENERATION
   for (int i = 1; i <= n; i++)
   {
      code.EmitFormattedLine("","MAKEDUP");
      code.EmitFormattedLine("","POP","@SP:0D2");
      code.EmitFormattedLine("","SWAP");
      code.EmitFormattedLine("","DISCARD","#0D1");
   }
   code.EmitFormattedLine("","DISCARD","#0D1");
// ENDCODEGENERATION

   if ( tokens[0].type != PERIOD )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '.'");
   GetNextToken(tokens);

   ExitModule("AssignmentStatement");
}

//-----------------------------------------------------------
void ParseIFStatement(TOKEN tokens[])
//-----------------------------------------------------------
{
   void ParseORExpression(TOKEN tokens[],DATATYPE &datatype);
   void ParseStatement(TOKEN tokens[]);
   void GetNextToken(TOKEN tokens[]);

   char line[SOURCELINELENGTH+1];
   char Ilabel[SOURCELINELENGTH+1],Elabel[SOURCELINELENGTH+1];
   DATATYPE datatype;

   EnterModule("IFStatement");

   sprintf(line,"** **** IF statement (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);

   GetNextToken(tokens);

   if ( tokens[0].type != OBRACKET )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '['");
   GetNextToken(tokens);
   ParseORExpression(tokens,datatype);
   if ( tokens[0].type != CBRACKET )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting ']'");
   GetNextToken(tokens);
   if ( tokens[0].type != OBRACE )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '{'");
   GetNextToken(tokens);

   if ( datatype != BOOLEANTYPE )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean expression");

// CODEGENERATION
   sprintf(Elabel,"E%04d",code.LabelSuffix());
   code.EmitFormattedLine("","SETT");
   code.EmitFormattedLine("","DISCARD","#0D1");
   sprintf(Ilabel,"I%04d",code.LabelSuffix());
   code.EmitFormattedLine("","JMPNT",Ilabel);
// ENDCODEGENERATION

   while ( (tokens[0].type != OTHERWISEIF) && (tokens[0].type != OTHERWISE) && (tokens[0].type != CBRACE))
      ParseStatement(tokens);

// CODEGENERATION
   code.EmitFormattedLine("","JMP",Elabel);
   code.EmitFormattedLine(Ilabel,"EQU","*");
// ENDCODEGENERATION

   while ( tokens[0].type == OTHERWISEIF )
   {
      GetNextToken(tokens);
      if ( tokens[0].type != OBRACKET )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '['");
      GetNextToken(tokens);
      ParseORExpression(tokens,datatype);
      if ( tokens[0].type != CBRACKET )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting ']'");
      GetNextToken(tokens);
      if ( tokens[0].type != EXECUTE )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting 'EXECUTE'");
      GetNextToken(tokens);

      if ( datatype != BOOLEANTYPE )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean expression");

// CODEGENERATION
      code.EmitFormattedLine("","SETT");
      code.EmitFormattedLine("","DISCARD","#0D1");
      sprintf(Ilabel,"I%04d",code.LabelSuffix());
      code.EmitFormattedLine("","JMPNT",Ilabel);
// ENDCODEGENERATION

      while ( (tokens[0].type != OTHERWISEIF) && (tokens[0].type != OTHERWISE) && (tokens[0].type != CBRACE) )
         ParseStatement(tokens);

// CODEGENERATION
      code.EmitFormattedLine("","JMP",Elabel);
      code.EmitFormattedLine(Ilabel,"EQU","*");
// ENDCODEGENERATION

   }
   if ( tokens[0].type == OTHERWISE )
   {
      GetNextToken(tokens);
      while ( tokens[0].type != CBRACE )
         ParseStatement(tokens);
   }

   GetNextToken(tokens);

// CODEGENERATION
      code.EmitFormattedLine(Elabel,"EQU","*");
// ENDCODEGENERATION

   ExitModule("IFStatement");
}

//-----------------------------------------------------------
void ParseREPEATWHILEStatement(TOKEN tokens[])
//-----------------------------------------------------------
{
   void ParseORExpression(TOKEN tokens[],DATATYPE &datatype);
   void ParseStatement(TOKEN tokens[]);
   void GetNextToken(TOKEN tokens[]);

   char line[SOURCELINELENGTH+1];
   char Dlabel[SOURCELINELENGTH+1],Elabel[SOURCELINELENGTH+1];
   DATATYPE datatype;

   EnterModule("REPEATWHILEStatement");

   sprintf(line,"** **** REPEAT-WHILE statement (%4d)",tokens[0].sourceLineNumber);
   code.EmitUnformattedLine(line);

   GetNextToken(tokens);

// CODEGENERATION
   sprintf(Dlabel,"D%04d",code.LabelSuffix());
   sprintf(Elabel,"E%04d",code.LabelSuffix());
   code.EmitFormattedLine(Dlabel,"EQU","*");
// ENDCODEGENERATION

   while ( tokens[0].type != WHILE )
      ParseStatement(tokens);
   GetNextToken(tokens);
   if ( tokens[0].type != OBRACKET )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '['");
   GetNextToken(tokens);
   ParseORExpression(tokens,datatype);
   if ( tokens[0].type != CBRACKET )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting ']'");
   GetNextToken(tokens);
   if ( tokens[0].type != OBRACE )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting '{'");
   GetNextToken(tokens);

   if ( datatype != BOOLEANTYPE )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean expression");

// CODEGENERATION
   code.EmitFormattedLine("","SETT");
   code.EmitFormattedLine("","DISCARD","#0D1");
   code.EmitFormattedLine("","JMPNT",Elabel);
// ENDCODEGENERATION

   while ( tokens[0].type != CBRACE )
      ParseStatement(tokens);

   GetNextToken(tokens);

// CODEGENERATION
   code.EmitFormattedLine("","JMP",Dlabel);
   code.EmitFormattedLine(Elabel,"EQU","*");
// ENDCODEGENERATION

   ExitModule("REPEATWHILEStatement");
}

//-----------------------------------------------------------
void ParseORExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseANDExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("ORExpression");

   ParseANDExpression(tokens,datatypeLHS);

   if ( (tokens[0].type == OR) || (tokens[0].type == NOR) || (tokens[0].type == XOR) )
   {
      while ( (tokens[0].type == OR) || (tokens[0].type == NOR) || (tokens[0].type == XOR) )
      {
         TOKENTYPE operation = tokens[0].type;

         GetNextToken(tokens);
         ParseANDExpression(tokens,datatypeRHS);
   
// CODEGENERATION
         switch ( operation )
         {
            case OR:

// STATICSEMANTICS
               if ( !((datatypeLHS == BOOLEANTYPE) && (datatypeRHS == BOOLEANTYPE)) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operands");
// ENDSTATICSEMANTICS
   
               code.EmitFormattedLine("","OR");
               datatype = BOOLEANTYPE;
               break;
            case NOR:
   
// STATICSEMANTICS
               if ( !((datatypeLHS == BOOLEANTYPE) && (datatypeRHS == BOOLEANTYPE)) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operands");
// ENDSTATICSEMANTICS
   
               code.EmitFormattedLine("","NOR");
               datatype = BOOLEANTYPE;
               break;
            case XOR:
   
// STATICSEMANTICS
               if ( !((datatypeLHS == BOOLEANTYPE) && (datatypeRHS == BOOLEANTYPE)) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operands");
// ENDSTATICSEMANTICS
   
               code.EmitFormattedLine("","XOR");
               datatype = BOOLEANTYPE;
               break;
         }
      }
// CODEGENERATION

   }
   else
      datatype = datatypeLHS;

   ExitModule("ORExpression");
}

//-----------------------------------------------------------
void ParseANDExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseNOTExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("ANDExpression");

   ParseNOTExpression(tokens,datatypeLHS);

   if ( (tokens[0].type == AND) || (tokens[0].type == NAND) )
   {
      while ( (tokens[0].type == AND) || (tokens[0].type == NAND) )
      {
         TOKENTYPE operation = tokens[0].type;
  
         GetNextToken(tokens);
         ParseANDExpression(tokens,datatypeRHS);
   
         switch ( operation )
         {
            case AND:
               if ( !((datatypeLHS == BOOLEANTYPE) && (datatypeRHS == BOOLEANTYPE)) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operands");
               code.EmitFormattedLine("","AND");
               datatype = BOOLEANTYPE;
               break;
            case NAND:
               if ( !((datatypeLHS == BOOLEANTYPE) && (datatypeRHS == BOOLEANTYPE)) )
                  ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operands");
               code.EmitFormattedLine("","NAND");
               datatype = BOOLEANTYPE;
               break;
         }
      }
   }
   else
      datatype = datatypeLHS;

   ExitModule("ANDExpression");
}

//-----------------------------------------------------------
void ParseNOTExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseCOMPAREExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeRHS;

   EnterModule("NOTExpression");

   if ( tokens[0].type == NOT )
   {
      GetNextToken(tokens);
      ParseCOMPAREExpression(tokens,datatypeRHS);

      if ( !(datatypeRHS == BOOLEANTYPE) )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting boolean operand");
      code.EmitFormattedLine("","NOT");
      datatype = BOOLEANTYPE;
   }
   else
      ParseCOMPAREExpression(tokens,datatype);

   ExitModule("NOTExpression");
}

//-----------------------------------------------------------
void ParseCOMPAREExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseBASICExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("COMPAREExpression");

   ParseBASICExpression(tokens,datatypeLHS);
   
   if ( (tokens[0].type == LESSER) || (tokens[0].type == LESSEREQUAL) || (tokens[0].type == EQUAL) || (tokens[0].type == GREATER) || (tokens[0].type == GREATEREQUAL) || (tokens[0].type == NOTEQUAL))
   {
      TOKENTYPE operation = tokens[0].type;

      GetNextToken(tokens);
      ParseBASICExpression(tokens,datatypeRHS);

      if ( (datatypeLHS != INTEGERTYPE) || (datatypeRHS != INTEGERTYPE) )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operands");
/*
      CMPI
      JMPXX     T????         ; XX = L,E,G,LE,NE,GE (as required)
      PUSH      #0X0000       ; push FALSE
      JMP       E????         ;    or 
T???? PUSH      #0XFFFF       ; push TRUE (as required)
E???? EQU       *
*/
      char Tlabel[SOURCELINELENGTH+1],Elabel[SOURCELINELENGTH+1];

      code.EmitFormattedLine("","CMPI");
      sprintf(Tlabel,"T%04d",code.LabelSuffix());
      sprintf(Elabel,"E%04d",code.LabelSuffix());
      switch ( operation )
      {
         case LESSER:
            code.EmitFormattedLine("","JMPL",Tlabel);
            break;
         case LESSEREQUAL:
            code.EmitFormattedLine("","JMPLE",Tlabel);
            break;
         case EQUAL:
            code.EmitFormattedLine("","JMPE",Tlabel);
            break;
         case GREATER:
            code.EmitFormattedLine("","JMPG",Tlabel);
            break;
         case GREATEREQUAL:
            code.EmitFormattedLine("","JMPGE",Tlabel);
            break;
         case NOTEQUAL:
            code.EmitFormattedLine("","JMPNE",Tlabel);
            break;
      }
      datatype = BOOLEANTYPE;
      code.EmitFormattedLine("","PUSH","#0X0000");
      code.EmitFormattedLine("","JMP",Elabel);
      code.EmitFormattedLine(Tlabel,"PUSH","#0XFFFF");
      code.EmitFormattedLine(Elabel,"EQU","*");
   }
   else
      datatype = datatypeLHS;

   ExitModule("COMPAREExpression");
}

//-----------------------------------------------------------
void ParseBASICExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseADVANCEDExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("BASICExpression");

   ParseADVANCEDExpression(tokens,datatypeLHS);

   if ( (tokens[0].type == ADDITION) || (tokens[0].type == SUBTRACTION) )
   {
      while ( (tokens[0].type == ADDITION) || (tokens[0].type == SUBTRACTION) )
      {
         TOKENTYPE operation = tokens[0].type;
         
         GetNextToken(tokens);
         ParseADVANCEDExpression(tokens,datatypeRHS);

         if ( (datatypeLHS != INTEGERTYPE) || (datatypeRHS != INTEGERTYPE) )
            ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operands");

         switch ( operation )
         {
            case ADDITION:
               code.EmitFormattedLine("","ADDI");
               break;
            case SUBTRACTION:
               code.EmitFormattedLine("","SUBI");
               break;
         }
         datatype = INTEGERTYPE;
      }
   }
   else
      datatype = datatypeLHS;
   
   ExitModule("BASICExpression");
}

//-----------------------------------------------------------
void ParseADVANCEDExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseFACTORExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("ADVANCEDExpression");

   ParseFACTORExpression(tokens,datatypeLHS);
   if ( (tokens[0].type == MULTIPLICATION) || (tokens[0].type == DIVISION) || (tokens[0].type ==  MODULUS) )
   {
      while ( (tokens[0].type == MULTIPLICATION) || (tokens[0].type == DIVISION) || (tokens[0].type ==  MODULUS) )
      {
         TOKENTYPE operation = tokens[0].type;
         
         GetNextToken(tokens);
         ParseFACTORExpression(tokens,datatypeRHS);

         if ( (datatypeLHS != INTEGERTYPE) || (datatypeRHS != INTEGERTYPE) )
            ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operands");

         switch ( operation )
         {
            case MULTIPLICATION:
               code.EmitFormattedLine("","MULI");
               break;
            case DIVISION:
               code.EmitFormattedLine("","DIVI");
               break;
            case MODULUS:
               code.EmitFormattedLine("","REMI");
               break;
         }
         datatype = INTEGERTYPE;
      }
   }
   else
      datatype = datatypeLHS;

   ExitModule("ADVANCEDExpression");
}

//-----------------------------------------------------------
void ParseFACTORExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParsePOWERExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   EnterModule("FACTORExpression");

   if ( (tokens[0].type == ABSOLUTE) || (tokens[0].type == ADDITION) || (tokens[0].type == SUBTRACTION) )
   {
      DATATYPE datatypeRHS;
      TOKENTYPE operation = tokens[0].type;

      GetNextToken(tokens);
      ParsePOWERExpression(tokens,datatypeRHS);

      if ( datatypeRHS != INTEGERTYPE )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operand");

      switch ( operation )
      {
         case ABSOLUTE:
/*
      SETNZPI
      JMPNN     E????
      NEGI                    ; NEGI or NEGF (as required)
E???? EQU       *
*/
            {
               char Elabel[SOURCELINELENGTH+1];
         
               sprintf(Elabel,"E%04d",code.LabelSuffix());
               code.EmitFormattedLine("","SETNZPI");
               code.EmitFormattedLine("","JMPNN",Elabel);
               code.EmitFormattedLine("","NEGI");
               code.EmitFormattedLine(Elabel,"EQU","*");
            }
            break;
         case ADDITION:
         // Do nothing (identity operator)
            break;
         case SUBTRACTION:
            code.EmitFormattedLine("","NEGI");
            break;
      }
      datatype = INTEGERTYPE;
   }
   else
      ParsePOWERExpression(tokens,datatype);

   ExitModule("FACTORExpression");
}

//-----------------------------------------------------------
void ParsePOWERExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseIncrements(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   DATATYPE datatypeLHS,datatypeRHS;

   EnterModule("POWERExpression");

   ParseIncrements(tokens,datatypeLHS);

   if ( tokens[0].type == POWER )
   {
      GetNextToken(tokens);

	  ParseIncrements(tokens,datatypeRHS);

      if ( (datatypeLHS != INTEGERTYPE) || (datatypeRHS != INTEGERTYPE) )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operands");

      code.EmitFormattedLine("","POWI");
      datatype = INTEGERTYPE;
   }
   else
      datatype = datatypeLHS;

   ExitModule("POWERExpression");
}

//-----------------------------------------------------------
void ParseIncrements(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseVID(TOKEN tokens[],bool asLValue,DATATYPE &datatype);
   void ParsePRIMARYExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   EnterModule("Increment/Decrement");

   if ( (tokens[0].type == INCREMENT) || (tokens[0].type == DECREMENT) )
   {
      DATATYPE datatypeRHS;
      TOKENTYPE operation = tokens[0].type;

      GetNextToken(tokens);
      ParseVID(tokens,true,datatypeRHS);

      if ( datatypeRHS != INTEGERTYPE )
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer operand");

      switch ( operation )
      {
         case INCREMENT:
            code.EmitFormattedLine("","PUSH","@SP:0D0");
            code.EmitFormattedLine("","PUSH","#0D1");
            code.EmitFormattedLine("","ADDI");
            code.EmitFormattedLine("","POP","@SP:0D1");       // side-effect
            code.EmitFormattedLine("","PUSH","@SP:0D0");
            code.EmitFormattedLine("","SWAP");
            code.EmitFormattedLine("","DISCARD","#0D1");      // value
            break;
         case DECREMENT:
            code.EmitFormattedLine("","PUSH","@SP:0D0");
            code.EmitFormattedLine("","PUSH","#0D1");
            code.EmitFormattedLine("","SUBI");
            code.EmitFormattedLine("","POP","@SP:0D1");       // side-effect
            code.EmitFormattedLine("","PUSH","@SP:0D0");
            code.EmitFormattedLine("","SWAP");
            code.EmitFormattedLine("","DISCARD","#0D1");      // value
            break;
      }
      datatype = INTEGERTYPE;
   }
   else
      ParsePRIMARYExpression(tokens,datatype);

   ExitModule("Increment/Decrement");
}

//-----------------------------------------------------------
void ParsePRIMARYExpression(TOKEN tokens[],DATATYPE &datatype)
//-----------------------------------------------------------
{
   void ParseVID(TOKEN tokens[],bool asLValue,DATATYPE &datatype);
   void ParseORExpression(TOKEN tokens[],DATATYPE &datatype);
   void GetNextToken(TOKEN tokens[]);

   EnterModule("PRIMARYExpression");

   switch ( tokens[0].type )
   {
      case INT:
         {
            char operand[SOURCELINELENGTH+1];
            
            sprintf(operand,"#0D%s",tokens[0].lexeme);
            code.EmitFormattedLine("","PUSH",operand);
            datatype = INTEGERTYPE;
            GetNextToken(tokens);
         }
         break;
      case TRUE:
         code.EmitFormattedLine("","PUSH","#0XFFFF");
         datatype = BOOLEANTYPE;
         GetNextToken(tokens);
         break;
      case FALSE:
         code.EmitFormattedLine("","PUSH","#0X0000");
         datatype = BOOLEANTYPE;
         GetNextToken(tokens);
         break;
      case OBRACKET:
         GetNextToken(tokens);
         ParseORExpression(tokens,datatype);
         if ( tokens[0].type != CBRACKET )
            ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting ]");
         GetNextToken(tokens);
         break;
      case VID:
         ParseVID(tokens,false,datatype);
         break;
      default:
         ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting integer, true, false, '[', or variable'");
         break;
   }

   ExitModule("PRIMARYExpression");
}

//-----------------------------------------------------------
void ParseVID(TOKEN tokens[],bool asLValue,DATATYPE &datatype)
//-----------------------------------------------------------
{
   void GetNextToken(TOKEN tokens[]);

   bool isInTable;
   int index;
   IDENTIFIERTYPE identifierType;

   EnterModule("Variable");

   if ( tokens[0].type != VID )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting identifier");

// STATICSEMANTICS
   index = identifierTable.GetIndex(tokens[0].lexeme,isInTable);
   if ( !isInTable )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Undefined identifier");
   
   identifierType = identifierTable.GetType(index);
   datatype = identifierTable.GetDatatype(index);

   if ( !((identifierType == PROGRAMMODULE_VARIABLE) ||
          (identifierType == PROGRAMMODULE_CONSTANT)) )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"Expecting variable or final identifier");
      
   if ( asLValue && (identifierType == PROGRAMMODULE_CONSTANT) )
      ProcessCompilerError(tokens[0].sourceLineNumber,tokens[0].sourceLineIndex,"FINAL may not be l-value");
// ENDSTATICSEMANTICS

// CODEGENERATION
   if ( asLValue )
      code.EmitFormattedLine("","PUSHA",identifierTable.GetReference(index));
   else
      code.EmitFormattedLine("","PUSH",identifierTable.GetReference(index));
// ENDCODEGENERATION

   GetNextToken(tokens);

   ExitModule("Variable");
}

//-----------------------------------------------------------
void Callback1(int sourceLineNumber,const char sourceLine[])
//-----------------------------------------------------------
{
   cout << setw(4) << sourceLineNumber << " " << sourceLine << endl;
}

//-----------------------------------------------------------
void Callback2(int sourceLineNumber,const char sourceLine[])
//-----------------------------------------------------------
{
   char line[SOURCELINELENGTH+1];
   
// CODEGENERATION
   sprintf(line,"** %4d %s",sourceLineNumber,sourceLine);
   code.EmitUnformattedLine(line);
// ENDCODEGENERATION
}

//-----------------------------------------------------------
void GetNextToken(TOKEN tokens[])
//-----------------------------------------------------------
{
   const char *TokenDescription(TOKENTYPE type);

   int i;
   TOKENTYPE type;
   char lexeme[SOURCELINELENGTH+1];
   int sourceLineNumber;
   int sourceLineIndex;
   char information[SOURCELINELENGTH+1];

//============================================================
// Move look-ahead "window" to make room for next token-and-lexeme
//============================================================
   for (int i = 1; i <= LOOKAHEAD; i++)
      tokens[i-1] = tokens[i];

   char nextCharacter = reader.GetLookAheadCharacter(0).character;

//============================================================
// "Eat" white space and comments
//============================================================
   do
   {
//    "Eat" any white-space (blanks and EOLCs and TABCs) 
      while ( (nextCharacter == ' ') || (nextCharacter == READER<CALLBACKSUSED>::EOLC) || (nextCharacter == READER<CALLBACKSUSED>::TABC) )
         nextCharacter = reader.GetNextCharacter().character;
         
//    "Eat" block comments (nesting allowed)
      if ( (nextCharacter == '*') && (reader.GetLookAheadCharacter(1).character == '*') && (reader.GetLookAheadCharacter(2).character == '*') )
      {
         int depth = 0;

         do
         {
            if ( (nextCharacter == '*') && (reader.GetLookAheadCharacter(1).character == '*') && (reader.GetLookAheadCharacter(2).character == '*') )
            {
               depth++;

#ifdef TRACESCANNER
   sprintf(information,"At (%4d:%3d) begin block comment depth = %d", reader.GetLookAheadCharacter(0).sourceLineNumber, reader.GetLookAheadCharacter(0).sourceLineIndex, depth);
   lister.ListInformationLine(information);
#endif

               nextCharacter = reader.GetNextCharacter().character;
               nextCharacter = reader.GetNextCharacter().character;
               nextCharacter = reader.GetNextCharacter().character;
            }
            else if ( (nextCharacter == ';') && (reader.GetLookAheadCharacter(1).character == '*') && (reader.GetLookAheadCharacter(2).character == '*') )
            {

#ifdef TRACESCANNER
   sprintf(information,"At (%4d:%3d)   end block comment depth = %d", reader.GetLookAheadCharacter(0).sourceLineNumber, reader.GetLookAheadCharacter(0).sourceLineIndex, depth);
   lister.ListInformationLine(information);
#endif

               depth--;
               nextCharacter = reader.GetNextCharacter().character;
               nextCharacter = reader.GetNextCharacter().character;
               nextCharacter = reader.GetNextCharacter().character;
            }
            else
               nextCharacter = reader.GetNextCharacter().character;
         }
         while ( (depth != 0) && (nextCharacter != READER<CALLBACKSUSED>::EOPC) );
         if ( depth != 0 ) 
            ProcessCompilerError(reader.GetLookAheadCharacter(0).sourceLineNumber, reader.GetLookAheadCharacter(0).sourceLineIndex, "Unexpected end-of-program");
      }

//    "Eat" line comment
      if ( (nextCharacter == '*') && (reader.GetLookAheadCharacter(1).character == '*') )
      {

#ifdef TRACESCANNER
   sprintf(information,"At (%4d:%3d) begin line comment",
      reader.GetLookAheadCharacter(0).sourceLineNumber,
      reader.GetLookAheadCharacter(0).sourceLineIndex);
   lister.ListInformationLine(information);
#endif

         do
            nextCharacter = reader.GetNextCharacter().character;
         while ( nextCharacter != READER<CALLBACKSUSED>::EOLC );
      } 


   } while ( (nextCharacter == ' ')
          || (nextCharacter == READER<CALLBACKSUSED>::EOLC)
          || (nextCharacter == READER<CALLBACKSUSED>::TABC)
          || ( (nextCharacter == '*') && (reader.GetLookAheadCharacter(1).character == '*') )
          || ( (nextCharacter == '*') && (reader.GetLookAheadCharacter(1).character == '*') && (reader.GetLookAheadCharacter(2).character == '*') ));


//============================================================
// Scan token
//============================================================
   sourceLineNumber = reader.GetLookAheadCharacter(0).sourceLineNumber;
   sourceLineIndex = reader.GetLookAheadCharacter(0).sourceLineIndex;

// reserved words or <identifier>
   if ( isalpha(nextCharacter) )
   {
      //char UCLexeme[SOURCELINELENGTH+1];

      i = 0;
      lexeme[i++] = nextCharacter;
      nextCharacter = reader.GetNextCharacter().character;
      while ( isalpha(nextCharacter) || isdigit(nextCharacter) || (nextCharacter == '_') )
      {
         lexeme[i++] = nextCharacter;
         nextCharacter = reader.GetNextCharacter().character;
      }
      lexeme[i] = '\0';
      
	  /* for (i = 0; i <= (int) strlen(lexeme); i++)
         UCLexeme[i] = toupper(lexeme[i]); */

      bool isFound = false;

      i = 0;
      while ( !isFound && (i <= (sizeof(TOKENTABLE)/sizeof(TOKENTABLERECORD))-1) )
      {												/* UCLexeme */
         if ( TOKENTABLE[i].isReservedWord && (strcmp(lexeme,TOKENTABLE[i].description) == 0) )
            isFound = true;
         else
            i++;
      }
      if ( isFound )
         type = TOKENTABLE[i].type;
      else
         type = VID;
   }
// <integer>
   else if ( isdigit(nextCharacter) )
   {
      i = 0;
      lexeme[i++] = nextCharacter;
      nextCharacter = reader.GetNextCharacter().character;
      while ( isdigit(nextCharacter) )
      {
         lexeme[i++] = nextCharacter;
         nextCharacter = reader.GetNextCharacter().character;
      }
      lexeme[i] = '\0';
      type = INT;
   }
   else
   {
      switch ( nextCharacter )
      {
// <string>
         case '"': 
            i = 0;
            nextCharacter = reader.GetNextCharacter().character;
            while ( (nextCharacter != '"') && (nextCharacter != READER<CALLBACKSUSED>::EOLC) )
            {
               if      ( (nextCharacter == '\\') && (reader.GetLookAheadCharacter(1).character == '"') )
               {
                  lexeme[i++] = nextCharacter;
                  nextCharacter = reader.GetNextCharacter().character;
               }
               else if ( (nextCharacter == '\\') && (reader.GetLookAheadCharacter(1).character == '\\') )
               {
                  lexeme[i++] = nextCharacter;
                  nextCharacter = reader.GetNextCharacter().character;
               }
               lexeme[i++] = nextCharacter;
               nextCharacter = reader.GetNextCharacter().character;
            }
            if ( nextCharacter == READER<CALLBACKSUSED>::EOLC )
               ProcessCompilerError(sourceLineNumber,sourceLineIndex,
                                    "Invalid string literal");
            lexeme[i] = '\0';
            type = STRING;
            reader.GetNextCharacter();
            break;
         case READER<CALLBACKSUSED>::EOPC: 
            {
               static int count = 0;
   
               if ( ++count > (LOOKAHEAD+1) )
                  ProcessCompilerError(sourceLineNumber,sourceLineIndex,
                                       "Unexpected end-of-program");
               else
               {
                  type = EOPTOKEN;
                  reader.GetNextCharacter();
                  lexeme[0] = '\0';
               }
            }
            break;
         case ';':
         	type = SEMICOLON;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
         case '.': 
            type = PERIOD;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case '(': 
            type = OPEN;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case ')': 
            type = CLOSE;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case '[': 
            type = OBRACKET;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case ']': 
            type = CBRACKET;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case '{':
            type = OBRACE;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case '}': 
            type = CBRACE;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
        case '<': 
            lexeme[0] = nextCharacter;
            nextCharacter = reader.GetNextCharacter().character;
            if ( nextCharacter == '=' )
            {
               type = LESSEREQUAL;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
               reader.GetNextCharacter();
            }
            else if ( nextCharacter == '<' )
            {
               type = INTO;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
               reader.GetNextCharacter();
            }
            else
            {
               type = LESSER;
               lexeme[1] = '\0';
            }
            break;
         case '=': 
            lexeme[0] = nextCharacter;
            nextCharacter = reader.GetNextCharacter().character;
            if ( nextCharacter == '=' )
            {
               type = EQUAL;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
               reader.GetNextCharacter();
            }
            else
            {
               type = UNKTOKEN;
               lexeme[1] = '\0';
               reader.GetNextCharacter();
            }
            break;
         case '>':
            lexeme[0] = nextCharacter;
            nextCharacter = reader.GetNextCharacter().character;
            if ( nextCharacter == '=' )
            {
               type = GREATEREQUAL;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
               reader.GetNextCharacter();
            }
            else
            {
               type = GREATER;
               lexeme[1] = '\0';
            }
            break;
// use character look-ahead to "find" '='
         case '!':
            lexeme[0] = nextCharacter;
            if ( reader.GetLookAheadCharacter(1).character == '=' )
            {
               nextCharacter = reader.GetNextCharacter().character;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
               reader.GetNextCharacter();
               type = NOTEQUAL;
            }
            else
            {
               type = UNKTOKEN;
               lexeme[1] = '\0';
               reader.GetNextCharacter();
            }
            break;
        case '+': 
            lexeme[0] = nextCharacter;
            if ( reader.GetLookAheadCharacter(1).character == '+' )
            {
               type = INCREMENT;
               nextCharacter = reader.GetNextCharacter().character;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
            }
            else
            {
			   type = ADDITION;
               lexeme[0] = nextCharacter; lexeme[1] = '\0';
        	}
            reader.GetNextCharacter();
            break;
         case '-': 
            lexeme[0] = nextCharacter;
            if ( reader.GetLookAheadCharacter(1).character == '-' )
            {
               type = DECREMENT;
               nextCharacter = reader.GetNextCharacter().character;
               lexeme[1] = nextCharacter; lexeme[2] = '\0';
            }
            else
            {
               type = SUBTRACTION;
               lexeme[0] = nextCharacter; lexeme[1] = '\0';
            }
            reader.GetNextCharacter();
            break;
         case '*': 
            type = MULTIPLICATION;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
         case '/': 
            type = DIVISION;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
            break;
         case '%': 
            type = MODULUS;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
         case '^': 
            type = POWER;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
         default:  
            type = UNKTOKEN;
            lexeme[0] = nextCharacter; lexeme[1] = '\0';
            reader.GetNextCharacter();
            break;
      }
   }

   tokens[LOOKAHEAD].type = type;
   strcpy(tokens[LOOKAHEAD].lexeme,lexeme);
   tokens[LOOKAHEAD].sourceLineNumber = sourceLineNumber;
   tokens[LOOKAHEAD].sourceLineIndex = sourceLineIndex;

#ifdef TRACESCANNER
   sprintf(information,"At (%4d:%3d) token = %12s lexeme = |%s|",
      tokens[LOOKAHEAD].sourceLineNumber,
      tokens[LOOKAHEAD].sourceLineIndex,
      TokenDescription(type),lexeme);
   lister.ListInformationLine(information);
#endif
}

//-----------------------------------------------------------
const char *TokenDescription(TOKENTYPE type)
//-----------------------------------------------------------
{
   int i;
   bool isFound;
   
   isFound = false;
   i = 0;
   while ( !isFound && (i <= (sizeof(TOKENTABLE)/sizeof(TOKENTABLERECORD))-1) )
   {
      if ( TOKENTABLE[i].type == type )
         isFound = true;
      else
         i++;
   }
   return ( isFound ? TOKENTABLE[i].description : "???????" );
}
