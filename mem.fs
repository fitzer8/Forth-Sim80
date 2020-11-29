\ ###############################################################
\ Title:    mem.fs
\ Func:     Various memory related functions.
\ Author:   Fitz
\ Ver:      0.0
\ ===============================================================
\ HISTORY
\ ===============================================================
\   DATE   #    NAME    # COMMENT
\ ===============================================================
\ 20180701 # Fitz       # Original.
\ 20180131 # Fitz       # Added drop to mem-dump-line to get rid
\                       # of junk on stack.
\ 20180202 # Fitz       # Changed ?non-printing to printable?
\ #############################################################*)
\ Todo
\ #############################################################*)

1024 constant 1k
64 constant pages
1k pages * constant MaxMem


maxalign
CREATE MEM MaxMem allot

: GetByte ( addr -- byte )
	MEM chars + c@
;

: byt@ ( adr -- byt )
	GetByte
;

: GetWord ( addr -- word )
	dup ( addr addr )
	1+ MEM + ( addr addr' )
	@ byte-mask ( addr byte )
	swap ( byte addr )
	MEM + ( byte addr' )
	@ byte-mask ( byte byte )
	unsplit ( word )
;


: PutByte ( byte addr -- )
	MEM chars + c!
;

: byt! ( byte addr -- )
	PutByte
;

: PutWord ( word addr -- word )
	swap ( addr word )
	split ( addr hi lo )
	rot ( hi lo addr )
	dup ( hi lo addr addr )
	rot ( hi addr addr lo )
	swap ( hi addr lo addr )
	\ MEM + ( hi addr lo mem-addr )
	PutByte ( hi addr )
	1+ PutByte ( hi mem-addr )
;

: init-mem ( -- )
	MaxMem 0 do
		0 i PutByte
	loop
;

\ init-mem

base @ hex

: mem-hdr ( -- )
	." |=========================================================|===================|" cr
	." |                       Memory dump                       |       ASCII       |" cr
	." |=========================================================|===================|" cr
	." | Addr | 00 01 02 03 04 05 06 07  08 09 0A 0B 0C 0D 0E 0F | 01234567 89ABCDEF |" cr
	." |=========================================================|===================|" cr
; 

: &type ( addr -- )
	space
	10 0 do ( addr )
		dup ( addr addr )
		i + ( addr addr'  )
		GetByte ( addr addr' ch-byte )
		dup  ( addr addr' ch-byte ch-byte )
		printable? ( addr addr ch-byte flag )
		if ( addr addr' ch-byte )
			drop ( addr addr' )
			2e ( .) ( addr addr' 0x2e )
		then ( addr addr' ch-byte )
		emit ( addr addr' )
		I 7 = if
			."  "
		then
	loop ( addr )
	."  |"
; 

: PrintByte ( byte -- )
	.byt bl emit
;


: mem-dump-line ( addr -- addr )
	." | "
	dup ( addr addr )
	.wrd ."  | " ( addr )
	10 0 do ( addr )
		dup ( addr addr )
		I + ( addr addr' )
		GetByte ( addr byte )
		PrintByte ( addr )
		I 7 = if
			."  "
		then
	loop ( addr )
	." |"
	drop
;

: mem-dump ( addr n -- )
	cr
	mem-hdr
	10 /mod ( addr rest rows )
	swap ( addr rows rest )
	if 1 + then 0 ( addr rows 0 )
	do ( addr )
		dup ( addr addr )
		mem-dump-line ( addr addr )
		&type
		10 + ( addr addr' )
		cr
	loop ( addr addr' )
	drop ( )
	." |=========================================================|===================|" cr
;

: .mem ( addr len )
	mem-dump
;

\ cr cr .s cr

base !


init-mem


