# Java++ (C / C++ / Java)

This project implements *Java++*, a small teaching language inspired by C++ & Java, along with a C++ compiler that translates `.java++` source code into STM assembly (`.stm`). Programs can then be assembled and executed using the included *STM* (Simple Target Machine) assembler + simulator.

## Features
- Custom programming language combining C++ and Java features
- Complete compiler implementation
- Documentation and language reference manual

---

## Requirements
- Command Prompt/Terminal
- *Optional:* C++ compiler (to rebuild *Java++Compiler*)
- *Optional:* C compiler (to rebuild *STM*)

---

## Project Layout
Java++/
- `docs/`
  - `assignments/`
  - `documentation/`
  - `test programs/`
- `src/`
	- `Java++Compiler.cpp`
	- `Java++Compiler.exe`
	- `STM.c`
	- `STM.exe`
	- `java++.h`

> **Important:** `Java++Compiler.cpp` includes `java++.h` using a relative path in the source.  
> If your folder layout differs, either (1) move files to match the include path, or (2) update the `#include` line to point to your local `java++.h`.


---

## Setup and Running
1. Download or clone this repository.
2. Navigate to the `Java++/` project directory.
3. Build the compiler and STM (or use the included `.exe` files).
4. Choose a `.java++` test program from `docs/test programs/`.
5. Compile the program to `.stm`, then assemble + run it in STM.

> **Note:** The compiler expects the `.java++` file to be in the **current working directory**.  
> To compile the provided test programs, you must copy the `.java++` file from `docs/test programs/` into `src/` before running the compiler.

### Running the Compiler
1. Copy a test program from `docs/test programs/` into `src/`.

	Example (Windows File Explorer):
	- Copy: `Java++/docs/test programs/P1.java++`
	- Paste into: `Java++/src/P1.java++`

2. Open Command Prompt/Terminal and navigate to the project `src/` directory.
3. *Optional:* Build the compiler (skip if you are using `Java++Compiler.exe`).
4. Run the compiler (`Java++Compiler.exe`). When prompted `Source filename?`, enter the base filename (no extension).

	Example: for `P1.java++`, type `P1`.

This generates (in `src/`):
- `P1.stm`
- `P1.list`


### Running STM
1. Open command prompt/terminal and navigate to the same project src directory.
2. *Optional:* Build STM (skip if you are using `STM.exe`).
3. Run the compiler (`STM.exe`), then when prompted ```'Source filename?'``` , enter the same base filename you compiled (no extension).

	Example: For P1.stm, type ```P1```.

STM reads _P1.stm_, produces _P1.log_, and executes the program.

---

## Running a Java++ Program
Minimal example (_Hello.java++_):

```ts
**----------------------------------------
** Ben Ebadinia
** Hello.java++
**----------------------------------------
START
	coutln("\"Howdy, world!\"").
FIN
```

Compile (*Java++Compiler*) → Run (*STM*) using the same base name (`Hello`) at both prompts.

---

## Troubleshooting
- Compiler can’t open source file: make sure your program is named `<name>.java++` and you typed only `<name>` at the prompt.
- STM can’t open source file: make sure the compiler successfully produced `<name>.stm` first.
- Include path error for `java++.h`: update the `#include` path in `Java++Compiler.cpp` or reorganize the `src/` files to match the include.
- Paths with spaces: the prompt-based filename input typically reads a single token, so compiling from a directory path that includes spaces can fail. If needed, copy the test program into `src/` before compiling.
- Output files “missing”: `.stm`, `.list`, and `.log` are created in the current working directory (where you launched the compiler/STM), usually `src/`.
