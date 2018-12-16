; --------------------------------------------------------
CODE segment para 'code'
assume cs:CODE, ds:CODE,es:CODE,ss:CODE
org 100h
begin: jmp main

x dw 4
y dw 4
col db 3

main proc near

mov al, byte ptr cs:82h
xor ah,ah
sub ax, 30h
mov cx, 100
imul cx

mov bx,x
add bx,ax
mov x,bx

mov al, byte ptr cs:83h
xor ah,ah
sub ax, 30h
mov cx, 10
imul cx

mov bx,x
add bx,ax
mov x,bx

mov al, byte ptr cs:84h
xor ah,ah
sub ax, 30h

mov bx,x
add bx,ax
mov x,bx

mov al, byte ptr cs:86h
xor ah, ah
sub ax, 30h
mov cx, 100
imul cx

mov bx,y
add bx,ax
mov y,bx

mov al, byte ptr cs:87h
xor ah, ah
sub ax, 30h
mov cx, 10
imul cx

mov bx,y
add bx,ax
mov y,bx

mov al, byte ptr cs:88h
xor ah, ah
sub ax, 30h

mov bx,y
add bx,ax
mov y,bx

mov ah,0
mov al,4
int 10h

mov ah,0Bh 
mov bx,0101h
int 10h

push 0B800h
pop es 

mov ax,y
mov cl,2
div cl

cmp ah,1 
je @m1 
mov di,0000h 

jmp @m2

@m1:
	mov di,2000h
@m2:

mov bl,al 
mov bh,0

mov ax,320
mul bx 

add ax,x 
cwd

mov bx,4 
div bx
add di,ax 

mov ax,x ;
mov bl,4
div bl

cmp ah,3 
je @three

cmp ah,2 
je @two

cmp ah,1 
je @one

mov bl,es:[di]
and bl,00111111b
mov al,col
mov cl,6
shl al,cl 
or al,bl

jmp @end

@three:
mov bl,es:[di]
and bl,11111100b
mov al,col
or al,bl
jmp @end

@two: 
mov bl,es:[di]
and bl,11110011b
mov al,col
mov cl,2
shl al,cl
or al,bl
jmp @end

@one:
mov bl,es:[di]
and bl,11001111b
mov al,col
mov cl,4
shl al,cl
or al,bl

@end:
mov es:[di],al 

mov ah,08
int 21h

ret
main endp

CODE ends
end begin