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

\ maxalign create inst-tbl 256 allot

base @ hex

: inst00 ( byt -- )
	." inst00" cr
	dup		( byt byt )
;

: nop 1 inc-PC ;

: unk 1 inc-PC ;

: hlt 1 inc-PC ;

: out 2 inc-PC ;

: in 2 inc-PC ;

: di 1 inc-PC ;

: ei 1 inc-PC ;

\ : imm-b@ ( -- byt )
\ : imm-w@ ( -- wrd )
\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Process lxi instructions.
\
: lxi ( opcode -- )
	dup .s

	CASE
		01 OF imm-w@ !BC ENDOF
		11 OF imm-w@ !DE ENDOF
		21 OF imm-w@ !HL ENDOF
		31 OF imm-w@ !SP ENDOF
	ENDCASE
	3 inc-PC
;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Process stax instructions.
\
: stax ( opcode -- )
	CASE
		02 OF @A @BC PutByte ENDOF
		12 OF @A @DE PutByte ENDOF
	ENDCASE
	1 inc-PC
;

: inx ( opcode -- )
	CASE
		03 OF @BC 1+ !BC ENDOF
		13 OF @DE 1+ !DE ENDOF
		23 OF @HL 1+ !HL ENDOF
		33 OF @SP 1+ !SP ENDOF
	ENDCASE
	1 inc-PC
;

maxalign create inst-tbl 
\ ' nop 0 inst-tbl + !
 0 cells + ' nop ,
 1 cells + ' lxi ,

tbl 0 cells + ' b00 ,

: step ( -- )
	\ @PC
	\ GetByte dup
	\ byt[PC] ( byt )
        (PC)b@ ( byt )
	dup ( byt byt )
	CASE
		\ misc/control instructions
		00 OF nop ENDOF
		01 OF nop ENDOF

		10 OF unk ENDOF
		20 OF unk ENDOF
		30 OF unk ENDOF
		08 OF unk ENDOF
		18 OF unk ENDOF
		28 OF unk ENDOF
		38 OF unk ENDOF

		76 OF hlt ENDOF

		0d3 OF out ENDOF

		0db OF in ENDOF

		0f3 OF di ENDOF

		0fb OF ei ENDOF


		\ jumps/calls instructions
\		0c0 OF rnz ENDOF
\		0d0 OF rnc ENDOF
\		0e0 OF rpo ENDOF
\		0f0 OF rp ENDOF

\		0c2 OF jnz ENDOF
\		0d2 OF jnc ENDOF
\		0e2 OF jpo ENDOF
\		0f2 OF jp ENDOF

\		0c3 OF jmp ENDOF

\		0c4 OF cnz ENDOF
\		0d4 OF cnc ENDOF
\		0e4 OF cpo ENDOF
\		0f4 OF cp ENDOF

\		0c7 OF rst0 ENDOF
\		0d7 OF rst1 ENDOF
\		0e7 OF rst2 ENDOF
\		0f7 OF rst3 ENDOF

\		0c8 OF rz ENDOF
\		0d8 OF rc ENDOF
\		0e8 OF rpe ENDOF
\		0f8 OF rm ENDOF

\		0c9 OF ret ENDOF
\		0d9 OF ret ENDOF
\		0e9 OF pchl ENDOF

\		0ca OF jz ENDOF
\		0da OF jc ENDOF
\		0ea OF jpe ENDOF
\		0fa OF jm ENDOF

\		0cb OF unk ENDOF

\		0cc OF cz ENDOF
\		0dc OF cc ENDOF
\		0ec OF cpe ENDOF
\		0fc OF cm ENDOF

\		0cd OF call ENDOF
\		0dd OF unk ENDOF
\		0ed OF unk ENDOF
\		0fd OF unk ENDOF

\		0cf OF rst4 ENDOF
\		0df OF rst5 ENDOF
\		0ef OF rst6 ENDOF
\		0ff OF rst7 ENDOF


		\ 8bit load/store/move instructions
		02 OF stax ENDOF
		12 OF stax ENDOF

\		32 OF sta  ENDOF

\		06 OF mvi ENDOF
\		16 OF mvi ENDOF
\		26 OF mvi ENDOF
\		36 OF mvi ENDOF

\		0A OF ldax ENDOF
\		1A OF ldax ENDOF
\		3A OF ldax ENDOF

\		0E OF mvi ENDOF
\		1E OF mvi ENDOF
\		2E OF mvi ENDOF
\		3E OF mvi ENDOF

\		40 OF mov ENDOF
\		41 OF mov ENDOF
\		42 OF mov ENDOF
\		43 OF mov ENDOF
\		44 OF mov ENDOF
\		45 OF mov ENDOF
\		46 OF mov ENDOF
\		47 OF mov ENDOF
\		48 OF mov ENDOF
\		49 OF mov ENDOF
\		4a OF mov ENDOF
\		4b OF mov ENDOF
\		4c OF mov ENDOF
\		4d OF mov ENDOF
\		4e OF mov ENDOF
\		4f OF mov ENDOF
\		50 OF mov ENDOF
\		51 OF mov ENDOF
\		52 OF mov ENDOF
\		53 OF mov ENDOF
\		54 OF mov ENDOF
\		55 OF mov ENDOF
\		56 OF mov ENDOF
\		57 OF mov ENDOF
\		58 OF mov ENDOF
\		59 OF mov ENDOF
\		5a OF mov ENDOF
\		5b OF mov ENDOF
\		5c OF mov ENDOF
\		5d OF mov ENDOF
\		5e OF mov ENDOF
\		5f OF mov ENDOF
\		60 OF mov ENDOF
\		61 OF mov ENDOF
\		62 OF mov ENDOF
\		63 OF mov ENDOF
\		64 OF mov ENDOF
\		65 OF mov ENDOF
\		66 OF mov ENDOF
\		67 OF mov ENDOF
\		68 OF mov ENDOF
\		69 OF mov ENDOF
\		6a OF mov ENDOF
\		6b OF mov ENDOF
\		6c OF mov ENDOF
\		6d OF mov ENDOF
\		6e OF mov ENDOF
\		6f OF mov ENDOF
\		70 OF mov ENDOF
\		71 OF mov ENDOF
\		72 OF mov ENDOF
\		73 OF mov ENDOF
\		74 OF mov ENDOF
\		75 OF mov ENDOF
\		77 OF mov ENDOF
\		78 OF mov ENDOF
\		79 OF mov ENDOF
\		7a OF mov ENDOF
\		7b OF mov ENDOF
\		7c OF mov ENDOF
\		7d OF mov ENDOF
\		7e OF mov ENDOF
\		7f OF mov ENDOF


		\ 16bit load/store/move instructions
		01 OF lxi ENDOF
		11 OF lxi ENDOF
		21 OF lxi ENDOF
		31 OF lxi ENDOF

\		22 OF shld ENDOF

\		2A OF lhld ENDOF

\		0c1 OF pop ENDOF
\		0d1 OF pop ENDOF
\		0e1 OF pop ENDOF
\		0f1 OF pop ENDOF

\		0e3 OF xthl ENDOF

\		0c5 OF push ENDOF
\		0d5 OF push ENDOF
\		0e5 OF push ENDOF
\		0f5 OF push ENDOF

\		0f9 OF sphl ENDOF

\		0eb OF xchg ENDOF


\		\ 8bit arithmatic/logical instructions
\		04 OF inr ENDOF
\		14 OF inr ENDOF
\		24 OF inr ENDOF
\		34 OF inr ENDOF

\		05 OF dcr ENDOF
\		15 OF dcr ENDOF
\		25 OF dcr ENDOF
\		35 OF dcr ENDOF

\		07 OF rlc ENDOF
\		17 OF ral ENDOF
\		27 OF daa ENDOF
\		37 OF stc ENDOF

\		0C OF inr ENDOF
\		1C OF inr ENDOF
\		2C OF inr ENDOF
\		3C OF inr ENDOF

\		0D OF dcr ENDOF
\		1D OF dcr ENDOF
\		2D OF dcr ENDOF
\		3D OF dcr ENDOF

\		0F OF rrc ENDOF
\		1F OF rar ENDOF
\		2F OF cma ENDOF
\		3F OF cmc ENDOF

\		80 OF add ENDOF
\		81 OF add ENDOF
\		82 OF add ENDOF
\		83 OF add ENDOF
\		84 OF add ENDOF
\		85 OF add ENDOF
\		86 OF add ENDOF
\		87 OF add ENDOF
\		88 OF adc ENDOF
\		89 OF adc ENDOF
\		8a OF adc ENDOF
\		8b OF adc ENDOF
\		8c OF adc ENDOF
\		8d OF adc ENDOF
\		8e OF adc ENDOF
\		8f OF adc ENDOF

\		90 OF sub ENDOF
\		91 OF sub ENDOF
\		92 OF sub ENDOF
\		93 OF sub ENDOF
\		94 OF sub ENDOF
\		95 OF sub ENDOF
\		96 OF sub ENDOF
\		97 OF sub ENDOF
\		98 OF sbb ENDOF
\		99 OF sbb ENDOF
\		9a OF sbb ENDOF
\		9b OF sbb ENDOF
\		9c OF sbb ENDOF
\		9d OF sbb ENDOF
\		9e OF sbb ENDOF
\		9f OF sbb ENDOF

\		0a0 OF ana ENDOF
\		0a1 OF ana ENDOF
\		0a2 OF ana ENDOF
\		0a3 OF ana ENDOF
\		0a4 OF ana ENDOF
\		0a5 OF ana ENDOF
\		0a6 OF ana ENDOF
\		0a7 OF ana ENDOF
\		0a8 OF xra ENDOF
\		0a9 OF xra ENDOF
\		0aa OF xra ENDOF
\		0ab OF xra ENDOF
\		0ac OF xra ENDOF
\		0ad OF xra ENDOF
\		0ae OF xra ENDOF
\		0af OF xra ENDOF

\		0b0 OF ora ENDOF
\		0b1 OF ora ENDOF
\		0b2 OF ora ENDOF
\		0b3 OF ora ENDOF
\		0b4 OF ora ENDOF
\		0b5 OF ora ENDOF
\		0b6 OF ora ENDOF
\		0b7 OF ora ENDOF
\		0b8 OF cmp ENDOF
\		0b9 OF cmp ENDOF
\		0ba OF cmp ENDOF
\		0bb OF cmp ENDOF
\		0bc OF cmp ENDOF
\		0bd OF cmp ENDOF
\		0be OF cmp ENDOF
\		0bf OF cmp ENDOF

\		0c6 OF adi ENDOF
\		0d6 OF sui ENDOF
\		0e6 OF ani ENDOF
\		0f6 OF ori ENDOF

\		0be OF aci ENDOF
\		0be OF sbi ENDOF
\		0be OF xri ENDOF
\		0be OF cpi ENDOF


		\ 16bit arithmatic/logical instructions
		03 OF inx ENDOF
		13 OF inx ENDOF
		23 OF inx ENDOF
		33 OF inx ENDOF

\		09 OF dad ENDOF
\		19 OF dad ENDOF
\		29 OF dad ENDOF
\		39 OF dad ENDOF

\		0B OF dcx ENDOF
\		1B OF dcx ENDOF
\		2B OF dcx ENDOF
\		3B OF dcx ENDOF


		." Rest" cr
	ENDCASE
\	inst-tbl + @
\	execute
	.regs
	0 40 mem-dump
;


base !




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
\ needs regs.fs

\ maxalign create tbl 256 allot
\      create v3
\        5 , 4 , 3 , 2 , 1 ,
\      v3 @ .
\      v3 cell+ @ .
\      v3 2 cells + @ .
\      v3 5 cells dump

base @ hex

: b00 ( byt -- )
	." b00" cr
;

: b01 ( byt -- )
	." b01" cr
;

		0100 !HL
		.reg

create tbl

tbl 00 cells + ' nop ,
tbl 01 cells + ' lxi ,

tbl 00 cells + @ execute

