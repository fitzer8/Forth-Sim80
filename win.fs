\ User Interface for 8080 Simulator
\
: title ( -- )
	80 0 do
		cr
	loop
	25 0 at-xy ." 8080 Stepping Monitor  0.0"
;

 0 constant reg-offset
12 constant spec-offset
24 constant flg-offset
35 constant stak-offset
43 constant bkpt-offset

: reg_hdr ( -- )
	reg-offset  2 at-xy ." REGISTERS "
	reg-offset  3 at-xy ." ========= "
	reg-offset  4 at-xy ."  BC: "
	reg-offset  5 at-xy ."  DE: "
	reg-offset  6 at-xy ."  HL: "
	reg-offset  7 at-xy ."   M: "
	reg-offset  8 at-xy ."   A: "
	reg-offset  9 at-xy ." BC': "
	reg-offset 10 at-xy ." DE': "
	reg-offset 11 at-xy ." HL': "
	reg-offset 12 at-xy ."  M': "
	reg-offset 13 at-xy ."  A': "
;

: spec_hdr ( -- )
	spec-offset   2 at-xy ."  SPECIAL "
	spec-offset   3 at-xy ." ========= "
	spec-offset   4 at-xy ." PCB: "
	spec-offset   5 at-xy ." RPC: "
	spec-offset   6 at-xy ."  PC: "
	spec-offset   7 at-xy ."  SP: "
	spec-offset   8 at-xy ."   X: "
	spec-offset   9 at-xy ."   Y: "
	spec-offset  10 at-xy ."   I: "
	spec-offset  10 at-xy ."  NI: "
;

: flg_hdr ( -- )
	flg-offset  2 at-xy ." FLAG R A "
	flg-offset  3 at-xy ." ======== "
	flg-offset  4 at-xy ." MI: "
	flg-offset  5 at-xy ." ZR: "
	flg-offset  6 at-xy ." AC: "
	flg-offset  7 at-xy ." PV: "
	flg-offset  8 at-xy ." NF: "
	flg-offset  9 at-xy ." CY: "
;

: stak_hdr ( -- )
	stak-offset  2 at-xy ." STACK "
	stak-offset  3 at-xy ." ===== "
;

: bkpt_hdr ( -- )
	bkpt-offset  2 at-xy ." BKPT "
	bkpt-offset  3 at-xy ." ==== "
;

: win ( -- )
	\ dark
	title
	reg_hdr		show_regs
	spec_hdr	show_spec
	flg_hdr		show_flg
	stak_hdr	show_stak
	bkpt_hdr	show_bkpt
0 25 at-xy
	cr
;

