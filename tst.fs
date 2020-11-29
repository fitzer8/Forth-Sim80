\ ###############################################################
\ Title:	sim80.fs
\ Func:		Intel 808 simulator
\ Author:	Fitz
\ Ver:		0.0
\ ===============================================================
\ HISTORY
\ ===============================================================
\   DATE   #    NAME    # COMMENT
\ ===============================================================
\ 20180629 # Fitz       # Original.
\ ###############################################################
needs regs.fs

hex

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Process NOP instruction
\
: nop ( opcode -- )
	pc} 1 + }pc
;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Process lxi instructions.
\
: lxi ( opcode -- )
	." lxi opcode " cr .s
	cr
	pc} 1 +		( opcode addr -- )
	GetWord		( opcode word -- )
	swap		( word opcode -- )

	CASE
		01 OF }bc ENDOF
		11 OF }de ENDOF
		21 OF }hl ENDOF
		31 OF }sp ENDOF
	ENDCASE
	3 pc} + }pc
;

: b00 ( byt -- )
	." b00" cr
;

: b01 ( byt -- )
	." b01" cr
;

create tbl
tbl 000 cells + ' nop ,
tbl 001 cells + ' lxi ,

0c 02 PutByte
0b 03 PutByte

.regs
0 40 .mem

0 tbl 000 cells + @ execute
1 tbl 001 cells + @ execute

.regs

