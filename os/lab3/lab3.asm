; --------------------------------------------------------
CODE segment para 'code'
assume cs:CODE, ds:CODE,es:CODE,ss:CODE
org 100h
begin: jmp main

FREQ_CODES DW 262, 277, 294, 311, 330, 349, 370, 392, 415, 440, 466, 494
SCAN_CODES DB 2h, 3h, 4h, 5h, 6h, 7h, 8h, 9h, 0Ah, 0Bh, 0Ch, 0Dh
UP_SCAN_CODES DB 81h, 82h, 83h, 84h, 85h, 86h, 87h, 88h, 89h, 8Ah, 8Bh, 8Ch, 8Dh
N DB 12


rezidentPart proc far
push ds di es ax bx cx dx
in al, 60h

mov cx,12 
@find_scan:
push cx

mov bp,cx

mov bl, byte ptr cs:SCAN_CODES + bp

cmp al, bl
je @job
pop cx
dec cx
cmp cx, -1
jne @find_scan

int 60h
jmp @cnt

@job:

mov al,10110110b
out 43h,al

in al,61h
or al,00000011b
out 61h,al

add bp,bp

mov dx, cs:FREQ_CODES + bp

mov al,dl
out 42h,al
mov al,dh
out 42h,al

sub bp,bp
sub bp,1
mov dl, byte ptr cs:UP_SCAN_CODES + bp

@repeat: 
mov ah,0h
int 09h

cmp al,dl 
jne @repeat

@cnt:

in al,61h 
and al,11111100b 
out 61H,al 

pop dx cx bx ax es di ds
mov al, 20h
out 20h, al

iret
finish EQU $

rezidentPart endp

main proc near

mov ah,35h
mov al,60h
int 21h
cmp bx,0
je @not_found
ret

@not_found:

mov ah, 35h
mov al,09h
int 21h

cli

push ds
mov dx,bx 
mov ax,es
mov ds,ax
mov ah,25h
mov al,60h
int 21h
pop ds

sti

lea dx,rezidentPart
mov ah,25h
mov al,09h
int 21h

lea dx, finish
int 27h

main endp

CODE ends
end begin