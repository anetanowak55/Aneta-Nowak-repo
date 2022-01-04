.code
StdDevAsm proc

; passed values:
; double[] array -> RCX
; double avg -> XMM1
; int start -> R8
; int end -> R9
; ref double result -> XMM0

MOV RAX, R8
VBROADCASTSD YMM3, XMM1				; broadcast a floating point value from XMM1 to four locations in YMM3

add_records_loop:
	CMP RAX, R9						; check if reached the end
	JA finished
	VMOVDQU YMM2, ymmword ptr [RCX] ; read 4 array elements to YMM2
	ADD RAX, 4						; add 4 to counter
	ADD RCX, 32						; add 32 to array pointer -> move 4 records forward

	VSUBPD YMM4, YMM2, YMM3			; substract avg from every element from the list -> substract YMM3 from YMM2 and save to YMM4
	VMULPD YMM5, YMM4, YMM4			; multiply YMM4 by YMM4 and save the result to YMM5

	VADDPD YMM7, YMM5, YMM6			; add YMM5 to YMM6 and store the result in YMM7
	VMOVDQU YMM6, YMM7				; copy the contents of YMM7 to YMM6
	JMP add_records_loop

finished:							; add 4 floating point values from ymm1 and save to result
	VHADDPD YMM11, YMM7, YMM10		; add horizontally ymm7 to an empty register ymm10 and save the result to ymm11
	VEXTRACTI128 xmm0, ymm11, 1		; extract the high quadword of ymm11 to xmm0
	ADDPD xmm0, xmm11
	ret

StdDevAsm endp
end