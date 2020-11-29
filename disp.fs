\ Display definitions

: .reg ( n col row -- )
	at-xy	\ get to correct screen location
	0	\ for numeric conversion
	<# # # #>	\ convert data
	type	\ show it
;

: .rp ( n col row -- )
	at-xy	\ get to correct screen location
	0	\ for numeric conversion
	<# # # # # #>	\ convert data
	type	\ show it
;

\ Print out the flag
: .flg ( n col row -- )
	at-xy	\ get to correct screen location
	base @	\ ( n base -- )
	swap	\ ( base n -- )
	2 base !	\ change to base to binary
	0	\ for numeric conversion
	<# # # # # # # # # #>
	type	\ show it
	base !
;

\ display all of the registers
: show_regs ( -- )
	 bc} 5 4  .rp
	 de} 5 5  .rp
	 hl} 5 6  .rp
	  m} 7 7  .reg
	  a} 7 8  .reg
	bc'} 5 9  .rp
	de'} 5 10 .rp
	hl'} 5 11 .rp
	 m'} 7 12 .reg
	 a'} 7 13 .reg
;

\ display the special registers
: show_spec ( -- )
	pcb} 17 4  .rp
	rpc} 17 5  .rp
	 pc} 17 6  .rp
	 sp} 17 7  .rp
	 ix} 17 8  .rp
	 iy} 17 9  .rp
	 pc} GetByte 17 10 .reg
;

\ display the flags
: show_flg ( -- )
	base @
	29 04 at-xy  f} hex 80 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 04 at-xy f'} hex 80 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 05 at-xy  f} hex 40 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 05 at-xy f'} hex 40 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 06 at-xy  f} hex 20 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 06 at-xy f'} hex 20 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 07 at-xy  f} hex 10 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 07 at-xy f'} hex 10 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 08 at-xy  f} hex 08 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 08 at-xy f'} hex 08 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 09 at-xy  f} hex 04 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 09 at-xy f'} hex 04 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 10 at-xy  f} hex 02 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 10 at-xy f'} hex 02 decimal and 0 > if ." 1 " else ." 0 " endif 
	29 11 at-xy  f} hex 01 decimal and 0 > if ." 1 " else ." 0 " endif 
	31 11 at-xy f'} hex 01 decimal and 0 > if ." 1 " else ." 0 " endif 
	\ base @ 2 base ! 29 20 at-xy f} 0 <# # # # # # # # # #> type base !
	base !
;

\ display the stack
: show_stak ( -- )
\ 	pcb} 17 4  .rp
\ 	rpc} 17 5  .rp
\ 	   0 17 4  .rp
\ 	   0 17 5  .rp
\ 	 pc} 17 6  .rp
\ 	 sp} 17 7  .rp
\ 	 ix} 17 8  .rp
\ 	 iy} 17 9  .rp
\ 	 pc} GetByte 17 10 .reg
;

\ display the breakpoints
: show_bkpt ( -- )
	bk0} 43  4 .rp	48  4 at-xy 0 .
	bk1} 43  5 .rp	48  5 at-xy 1 .
	bk2} 43  6 .rp	48  6 at-xy 2 .
	bk3} 43  7 .rp	48  7 at-xy 3 .
	bk4} 43  8 .rp	48  8 at-xy 4 .
	bk5} 43  9 .rp	48  9 at-xy 5 .
	bk6} 43 10 .rp	48 10 at-xy 6 .
	bk7} 43 11 .rp	48 11 at-xy 7 .
;

\ display the address offsets
: .num_hdr ( -- )
	base @ hex
	16 0 do		\ 00 - 0F
		i
		0 <# # # #> type
		space
	loop
	base !
;

\ display the alpha offsets
: .alpha_hdr ( -- )
	." 01234567 89ABCDEF"
;

\ display the header
: .hdr ( -- )
	cr
	." ADDR  "
	.num_hdr
	space
	.alpha_hdr
	cr
	." ----  "
	." -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --  "
	." -------- --------"
	cr
;

