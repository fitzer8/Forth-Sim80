\ utils.fs  

base @
hex

: printable? ( byte -- char )
	dup 
	20 < swap 7E > 
	or 
; 

: .bits8 ( byte -- )
	base @		\ n base
	swap 		\ base n
	2 base !	\ base n
	0 <# # # # # # # # # #> type cr	\ base
	base !
;

: .bits16 ( word -- )
	base @		\ n base
	swap 		\ base n
	2 base !	\ base n
	0 <# # # # # # # # # # # # # # # # # #> type cr	\ base
	base !
;

: byte-mask ( number -- byte )
	0ff and
;

: word-mask ( number -- word )
	0ffff and
;

: .byt ( byte -- )
	0 <# # # #> type
;

: .wrd ( word -- )
	0 <# # # # # #> type
;

: split ( word -- HiByte LoByte )
	0100 /mod
;

: unsplit ( LoByte HiByte -- word )
	0100 * +
;

: 2^ dup 0= if drop 1 else 1 swap 0 do 2* loop then ;
: bit?    ( byte idx -- flag )  2^ and 0= 0= ;
: bit-on  ( byte idx -- byte' ) 2^        or  ;
: bit-off ( byte idx -- byte' ) 2^ invert and ;
: bit-toggle ( toggle indexed bit )
	2dup bit? if bit-off else bit-on then ;

: chk-wrd ( n -- )
	dup
	0ffff > if
		0ffff and
	then
;

: chk-byt ( n -- )
	dup
	0ff > if
		0ff and
	then
;


base !



