.code
StdDevAsm proc

; passed values:
; double[] array -> RCX
; double avg -> XMM0
; int start -> RDX
; int end -> R8
; ref double result -> R9

MOV RAX, RDX

StdDevAsm endp
end