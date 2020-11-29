\ i80.fs  i8080 Simulator


\ 1024 constant 1k
\ 64 constant pages
\ 1k pages * 1 - constant MaxMem

\ needs ansi.fs
\ needs vt100.fs
needs utils.fs
needs mem.fs
needs regs.fs
needs disp.fs
needs win.fs
\ needs sim80.fs
\ needs fig-forth.fs


\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ TODO list
\
\ Finish LXI processing.
\ Finish instructions OUT, IN, EI, DI and all returns.
\ Finish instructions OUT, IN, EI, DI and all returns.
\ Finish NextInstr
\


page
0 0 at-xy 

\ cr
hex

10 }A
0F }F
0b }B
0c }C
0D }D
0E }E

\ Comments start here
0100 }bc
0FFFF }sp
0100 }pc


.regs


0a0f }af
.regs

\ BC@ ." BC: " .word cr 

\ 0 GetByte .byte cr

\ 1 0 PutByte
\ 0 GetByte .byte cr

\ 0b 0 PutByte
01 1 PutByte
02 0a PutByte
03 0b PutByte
\ ." Byte at address 0: " 0 GetByte .byte cr
\ ." Byte at address 1: " 1 GetByte .byte cr

\ ." Word at address 0: " 0 GetWord .word cr

\ 0e0f 2 PutWord
\ ." Word at address 2: " 2 GetWord .word cr

44 20 PutByte       \ DEADBEEF
45 21 PutByte
41 22 PutByte
44 23 PutByte
42 24 PutByte
45 25 PutByte
45 26 PutByte
46 27 PutByte


42 10 PutByte       \ DEAD
4245 10 PutWord
4546 12 PutWord

\ .regs
0 60 mem-dump


0000 }PC
.regs
\ 8 rPC reg+ bit? .
\ 0 rPC reg+ bit-on  .regs
\ 0 rPC reg+ bit-off .regs
\ bye


\ ." Test bit 8" cr
\ rAF 1 bit@ ." Bit 1 of AF: " . cr
\ 0100 bit? .



