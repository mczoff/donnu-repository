; --------------------------------------------------------
CODE segment para 'code'
assume cs:CODE, ds:CODE,es:CODE,ss:CODE
org 100h
begin: jmp main

rezidentPart proc far
push ds di es ax bx cx dx
in al, 60h
cmp al, 10h
je @job
int 60h
jmp @cnt
@job:

;calculate X_OFFSET
xor ax,ax
mov al, byte ptr cs:END_POS_X
sub al, byte ptr cs:START_POS_X
mov byte ptr cs:X_OFFSET, al 

;calculate Y_OFFSET
xor ax,ax
mov al, byte ptr cs:END_POS_Y
sub al, byte ptr cs:START_POS_Y
mov byte ptr cs:Y_OFFSET, al 

xor cx, cx
mov cl, byte ptr cs:HEIGHT_RECT

@heightcycle:
push cx

mov byte ptr cs:CUR_ROW, cl

xor cx, cx
mov cl, byte ptr cs:WIDTH_RECT

@widthcycle:
push cx

;prepare read cursor
mov bh,00h
mov dh,byte ptr cs:CUR_ROW ;height
mov dl,cl ;width
mov ah,02h
int 10h

;read 
mov bh,00h
mov ah,08h
int 10h
mov byte ptr cs:TMP_LABEL, al

;prepare write cursor
mov bh,00h
mov dh,byte ptr cs:CUR_ROW ;height
add dh,byte ptr cs:Y_OFFSET
mov dl,cl ;width
add dl,byte ptr cs:X_OFFSET

mov ah,02h
int 10h

;write
mov bh,00h
mov cx,1h
mov al, byte ptr cs:TMP_LABEL
mov ah,0Ah

int 10h

pop cx
sub cx,1
cmp cx, -1
jne @widthcycle

pop cx
sub cx,1
cmp cx, -1
jne @heightcycle

@cnt:
pop dx cx bx ax es di ds
mov al, 20h
out 20h, al

iret
finish EQU $

rezidentPart endp

FLOOD_STR DB '',10,13,'Have you tried to run a marathon with no practice?',10,13,'I hope not. You might pull a muscle',10,13,'You need to start small in order to achieve something big like that.',10,13,'When it comes to learning English, what if I told you that you can understand big ideas with just a little bit of text?',10,13,'You do not need to wait several years to deal with complex concepts.',10,13,'Just because you are learning a language does not mean you need to limit your thinking.',10,13,'Stories are all about going beyond reality',10,13,' It is no wonder that they let you understand big concepts with only a little bit of reading practice',10,13,'But this works better when you’re reading better stories.',10,13,'I am talking about award-winning short stories',10,13,'Told using language easily understood by beginners',10,13,'You get more time to focus on individual words',10,13,'These will not only improve your English reading comprehension','$'

START_POS_X DB 0
START_POS_Y DB 0

END_POS_X DB 20
END_POS_Y DB 20

WIDTH_RECT DB 12
HEIGHT_RECT DB 8

Y_OFFSET DB 2
X_OFFSET DB 2

CUR_ROW DB 1h

TMP_LABEL DB ?

main proc near

mov al, byte ptr cs:82h
mov ah, byte ptr cs:83h

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov START_POS_X,al


mov al, byte ptr cs:85h
mov ah, byte ptr cs:86h

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov START_POS_Y,al

mov al, byte ptr cs:88h
mov ah, byte ptr cs:89h

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov END_POS_X,al

mov al, byte ptr cs:8Bh
mov ah, byte ptr cs:8Ch

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov END_POS_Y,al

mov al, byte ptr cs:8Eh
mov ah, byte ptr cs:8Fh

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov WIDTH_RECT,al

mov al, byte ptr cs:91h
mov ah, byte ptr cs:92h

sub al, 30h
sub ah, 30h

mov cl,10
imul cl

add al,ah
mov HEIGHT_RECT,al

mov ah,35h
mov al,60h
int 21h
cmp bx,0
je @not_found
ret
mov ah,09h
lea dx, FLOOD_STR
int 21h

mov ah,09h
lea dx, FLOOD_STR
int 21h

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