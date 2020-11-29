\ regs.fs  
\ colorize.fs  Coloured .NAME and WORDS                20may93jaw

\ Copyright (C) 1995,1996,1997,1999,2001,2003,2007 Free Software Foundation, Inc.

\ This file is part of Gforth.

\ Gforth is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public License
\ as published by the Free Software Foundation, either version 3
\ of the License, or (at your option) any later version.

\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program. If not, see http://www.gnu.org/licenses/.

needs utils.fs
needs mem.fs

base @ hex

30 constant #regs
maxalign
create regs #regs cells allot
\ create regs #regs allot

: reg-name ( n -- )
	regs		\ n addr
	chars		\ n offset
	+		\ cell_addr
	constant	\ --
;

: reg+ regs chars + ;
: lo-reg 0 regs chars + + ;
: hi-reg 1 regs chars + + ;


: int2byte ( n addr -- n' addr )
	swap byte-mask swap
;

00 reg-name A		01 reg-name F
02 reg-name B		03 reg-name C
04 reg-name D		05 reg-name E
06 reg-name H		07 reg-name L
21 reg-name A'		22 reg-name F'
23 reg-name B'		24 reg-name C'
25 reg-name D'		26 reg-name E'
27 reg-name H'		28 reg-name L'

08 reg-name SPh		09 reg-name SPl
0a reg-name PCh		0b reg-name PCl

0c reg-name BK0h	0d reg-name BK0l
0e reg-name BK1h	0f reg-name BK1l
10 reg-name BK2h	12 reg-name BK2l
12 reg-name BK3h	14 reg-name BK3l
14 reg-name BK4h	16 reg-name BK4l
16 reg-name BK5h	18 reg-name BK5l
18 reg-name BK6h	1a reg-name BK6l
1a reg-name BK7h	1c reg-name BK7l

1c reg-name ST0h	1d reg-name ST0l
1e reg-name ST1h	1f reg-name ST1l
20 reg-name ST2h	21 reg-name ST2l
22 reg-name ST3h	23 reg-name ST3l
24 reg-name ST4h	25 reg-name ST4l
26 reg-name ST5h	27 reg-name ST5l
28 reg-name ST6h	29 reg-name ST6l
2a reg-name ST7h	2b reg-name ST7l

2c reg-name IXh		2d reg-name IXl
2e reg-name IYh		2f reg-name IYl
30 reg-name PCBh	31 reg-name PCBl
32 reg-name RPCh	33 reg-name RPCl



: a}  ( -- byte ) A c@ ;	: f}  ( -- byte ) F c@ ;
: b}  ( -- byte ) B c@ ;	: c}  ( -- byte ) C c@ ;
: d}  ( -- byte ) D c@ ;	: e}  ( -- byte ) E c@ ;
: h}  ( -- byte ) H c@ ;	: l}  ( -- byte ) L c@ ;

: af}   ( -- word ) f} a} unsplit ; 
: bc}   ( -- word ) c} b} unsplit ; 
: de}   ( -- word ) e} d} unsplit ; 
: hl}   ( -- word ) l} h} unsplit ; 

: pc}   ( -- word ) PCh  c@ PCl c@ unsplit ;
: pcb}  ( -- word ) PCBh c@ PCBl c@ unsplit ;
: rpc}  ( -- word ) RPCh c@ RPCl c@ unsplit ;
: sp}   ( -- word ) SPh  c@ SPl c@ unsplit ;
: bk0}  ( -- word ) BK0h c@ BK0l c@ unsplit ;
: bk1}  ( -- word ) BK1h c@ BK1l c@ unsplit ;
: bk2}  ( -- word ) BK2h c@ BK2l c@ unsplit ;
: bk3}  ( -- word ) BK3h c@ BK3l c@ unsplit ;
: bk4}  ( -- word ) BK4h c@ BK4l c@ unsplit ;
: bk5}  ( -- word ) BK5h c@ BK5l c@ unsplit ;
: bk6}  ( -- word ) BK6h c@ BK6l c@ unsplit ;
: bk7}  ( -- word ) BK7h c@ BK7l c@ unsplit ;
: st0}  ( -- word ) ST0h c@ ST0l c@ unsplit ;
: st1}  ( -- word ) ST1h c@ ST1l c@ unsplit ;
: st2}  ( -- word ) ST2h c@ ST2l c@ unsplit ;
: st3}  ( -- word ) ST3h c@ ST3l c@ unsplit ;
: st4}  ( -- word ) ST4h c@ ST4l c@ unsplit ;
: st5}  ( -- word ) ST5h c@ ST5l c@ unsplit ;
: st6}  ( -- word ) ST6h c@ ST6l c@ unsplit ;
: st7}  ( -- word ) ST7h c@ ST7l c@ unsplit ;


: }a	( byte -- ) A c! ;	: }f	( byte -- ) F c! ;
: }b	( byte -- ) B c! ;	: }c	( byte -- ) C c! ;
: }d	( byte -- ) D c! ;	: }e	( byte -- ) E c! ;
: }h	( byte -- ) H c! ;	: }l	( byte -- ) L c! ;

: }af   ( word -- ) split }a }f ;
: }bc   ( word -- ) split }b }c ;
: }de   ( word -- ) split }d }e ;
: }hl   ( word -- ) split }h }l ;

: }pc   ( word -- ) split PCl  c! PCh c! ;
: }sp   ( word -- ) split SPl  c! SPh c! ;
: }bk0  ( word -- ) split BK0l c! BK0h c! ;
: }bk1  ( word -- ) split BK1l c! BK1h c! ;
: }bk2  ( word -- ) split BK2l c! BK2h c! ;
: }bk3  ( word -- ) split BK3l c! BK3h c! ;
: }bk4  ( word -- ) split BK4l c! BK4h c! ;
: }bk5  ( word -- ) split BK5l c! BK5h c! ;
: }bk6  ( word -- ) split BK6l c! BK6h c! ;
: }bk7  ( word -- ) split BK7l c! BK7h c! ;
: }st0  ( word -- ) split ST0l c! ST0h c! ;
: }st1  ( word -- ) split ST1l c! ST1h c! ;
: }st2  ( word -- ) split ST2l c! ST2h c! ;
: }st3  ( word -- ) split ST3l c! ST3h c! ;
: }st4  ( word -- ) split ST4l c! ST4h c! ;
: }st5  ( word -- ) split ST5l c! ST5h c! ;
: }st6  ( word -- ) split ST6l c! ST6h c! ;
: }st7  ( word -- ) split ST7l c! ST7h c! ;

: ix}   ( -- word ) IXh  c@ IXl c@ unsplit ;
: iy}   ( -- word ) IYh  c@ IYl c@ unsplit ;

: a'}  ( -- byte ) A' c@ ;	: f'}  ( -- byte ) F' c@ ;
: b'}  ( -- byte ) B' c@ ;	: c'}  ( -- byte ) C' c@ ;
: d'}  ( -- byte ) D' c@ ;	: e'}  ( -- byte ) E' c@ ;
: h'}  ( -- byte ) H' c@ ;	: l'}  ( -- byte ) L' c@ ;

: af'}   ( -- word ) f'} a'} unsplit ; 
: bc'}   ( -- word ) c'} b'} unsplit ; 
: de'}   ( -- word ) e'} d'} unsplit ; 
: hl'}   ( -- word ) l'} h'} unsplit ; 

: m} ( -- byte ) hl} GetByte ;
: m'} ( -- byte ) hl'} GetByte ;

: .a ( -- ) a} .byt ;
: .f ( -- ) f} .byt ;
: .b ( -- ) b} .byt ;
: .c ( -- ) c} .byt ;
: .d ( -- ) d} .byt ;
: .e ( -- ) e} .byt ;
: .h ( -- ) h} .byt ;
: .l ( -- ) l} .byt ;

: .af  ( -- ) af}  .wrd ; 
: .bc  ( -- ) bc}  .wrd ;
: .de  ( -- ) de}  .wrd ;
: .hl  ( -- ) hl}  .wrd ;
: .pc  ( -- ) pc}  .wrd ;
: .sp  ( -- ) sp}  .wrd ;
: .bk0 ( -- ) bk0} .wrd ;
: .bk1 ( -- ) bk1} .wrd ;
: .bk2 ( -- ) bk2} .wrd ;
: .bk3 ( -- ) bk3} .wrd ;
: .bk4 ( -- ) bk4} .wrd ;
: .bk5 ( -- ) bk5} .wrd ;
: .bk6 ( -- ) bk6} .wrd ;
: .bk7 ( -- ) bk7} .wrd ;
: .st0 ( -- ) st0} .wrd ;
: .st1 ( -- ) st1} .wrd ;
: .st2 ( -- ) st2} .wrd ;
: .st3 ( -- ) st3} .wrd ;
: .st4 ( -- ) st4} .wrd ;
: .st5 ( -- ) st5} .wrd ;
: .st6 ( -- ) st6} .wrd ;
: .st7 ( -- ) st7} .wrd ;

\ Increment PC by n.
: pc+ ( n -- )
	pc} +
	chk-wrd
	}pc
;

\ : byt[PC] ( -- byt )
\ 	@PC
\ 	GetByte
\ ;
\ 
\ : (PC)b@ ( -- byt )
\ 	@PC
\ 	GetByte
\ ;
\ 
\ : imm-b@ ( -- byt )
\ 	@PC 1 +
\ 	GetByte
\ ;
\ 
\ : imm-w@ ( -- wrd )
\ 	@PC 1 +
\ 	GetWord
\ ;

: .regs ( -- )
	cr
	." ============================================================" cr
	." |                      Registers                           |" cr
	." |==========================================================|" cr
	." | Regular  |     Break Points      |                       |" cr
	." |==========|=======================|=======================|" cr
	." | AF: " .AF ."  | BK0: " .BK0 ."  | BK4: " .BK4 ."  | ST0: " .ST0 ."  | ST4: " .ST4 ."  | " cr
	." | BC: " .BC ."  | BK1: " .BK1 ."  | BK5: " .BK5 ."  | ST1: " .ST1 ."  | ST5: " .ST5 ."  | " cr
	." | DE: " .DE ."  | BK2: " .BK2 ."  | BK6: " .BK6 ."  | ST2: " .ST2 ."  | ST6: " .ST6 ."  | " cr
	." | HL: " .HL ."  | BK3: " .BK3 ."  | BK7: " .BK7 ."  | ST3: " .ST3 ."  | ST7: " .ST7 ."  | " cr
	." |==========|===============================================|" cr
	." | PC: " .PC ."  |  SP: " .SP ."  | Nxt Instruct:                     |" cr
	." ============================================================" cr
;

base !

