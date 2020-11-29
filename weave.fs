( empty )

( configuration )
: srcfile   s" tmp.com" ;
: outfile   s" /mnt/c/User/fitzpatf/Download/tmp.html" ;
: outfile   s" tmp.html" ;

( input buffer )
variable    'src
variable    #src

variable    fh


( command dispatcher )
variable    offset 
variable    'token
variable    #token
variable    'out
variable    #out

: open      srcfile r/o open-file throw fh ! ;
: close     fh @ close-file throw ;
: read      begin here 4096 fh @ read-file throw dup allot 0= until ;
: gulp      open read close ;
: start     here 'src ! ;
: finish    here 'src @ - #src ! ;
: slurp     start gulp finish ;
: open      outfile r/w create-file throw fh ! ;
: write     'out @ #out @ fh @ write-file throw ;
: spew      open write close ;

: addr      offset @ 'src @ + ;
: chr       addr c@ ;
: -ws       32 u> ;
: advance   1 offset +! ;
: seek      begin chr -ws while advance repeat ;
: token     addr seek addr over - advance 2dup #token ! 'token ! ;
: .token    'token @ #token @ type ;
: error     cr cr .token -1 abort" Command not found" ;
: command   token sfind if execute else error then ;


( process input buffer )

: rdrop     postpone r> postpone drop ; immediate
: call      >r ;
: entity    [char] & emit  type  [char] ; emit ;
: ===>      over = if drop r> call entity rdrop exit then rdrop ;

: either&   [char] & ===> s" amp" ;
: or<       [char] < ===> s" lt" ;
: or>       [char] > ===> s" gt" ;
: orEsc     dup [char] ~ = if drop command rdrop exit then ;

( vectored output )
: b-emit        c, ;
: b-type        begin dup while over c@ emit 1 /string repeat 2drop ;
: buffered      ['] b-emit is emit  ['] b-type is type ;
: interactive   ['] (emit) is emit   ['] (type) is type ;
: start         here 'out ! buffered ;
: finish        here 'out @ - #out ! interactive ;

: interpret chr advance either& or< or> orEsc ( else ) emit ;
: -end      offset @ #src @ u< ;
: format    0 offset ! begin -end while interpret repeat ;
: process   start format finish ;


( commands )
: iw        ." <i>" token type ." </i> " ;
: bw        ." <b>" token type ." </b> " ;

( kick off procedures )
: weave         slurp process spew ;
weave bye


