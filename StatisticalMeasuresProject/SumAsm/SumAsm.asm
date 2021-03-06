.code
SumAsm proc

; passed values:
; double[] array -> RCX
; int start -> RDX
; int end -> R8

VXORPS YMM3, YMM3, YMM3				; make sure ymm3 is empty

MOV RAX, RDX						; go to the correct index in the array
IMUL RAX, 8
ADD RCX, RAX

MOV RAX, RDX						; start loop at start index

add_records_loop:
	CMP RAX, R8
	JA finished
	VMOVDQU YMM2, ymmword ptr [RCX]		; read 4 array elements to YMM2
	ADD RAX, 4
	ADD RCX, 32
	VADDPD YMM1, YMM2, YMM3				; add YMM3 to YMM2 and store the result in YMM1
	VMOVDQU YMM3, YMM1					; copy the contents of YMM1 to YMM3
	JMP add_records_loop

finished:								; add 4 floating point values from ymm1 and save to result
	VHADDPD YMM11, YMM1, YMM10			; add horizontally ymm1 to an empty register ymm10 and save the result to ymm11
	VEXTRACTI128 xmm0, ymm11, 1			; extract the high quadword of ymm11 to xmm0
	ADDPD xmm0, xmm11					
	ret

SumAsm endp
end