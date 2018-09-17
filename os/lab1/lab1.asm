; --------------------------------------------------------
CODE segment para 'code'
assume cs:CODE, ds:CODE,es:CODE,ss:CODE
org 100h
begin: jmp main

successStr db 10, 13, 'SUCCESS!', 10, 13, '$'
failStr db 10, 13, 'FAIL!', 10, 13, '$'

currentDateInviteStr db 10, 13, 'CURRENT DATE:', 10, 13, '$'
enterDateInviteStr db 10, 13, 'ENTER NEW DATE IN FORMAT dd.MM.YYYY:', 10, 13, '$'
newStr db 10, 13, '$'

DAY db 2 dup(?)

PARSEDAY db ?
PARSEMOUNTH db ?
PARSEYEAR dw ?

TMPYEAR dw ?

SETDAY db ?
SETMOUNTH db ?
SETYEAR dw ?

buf db 11, 11 DUP(?)

main proc near

;show invite string 
mov ah,09h
lea dx, currentDateInviteStr
int 21h
CALL PRINTDATE

mov ah,09h
lea dx, enterDateInviteStr
int 21h

;get new date value
mov ah,0Ah
lea dx,buf
int 21h

mov ah,09h
lea dx, newStr
int 21h

;get setday var
mov al, buf+3
sub al, 30h
mov SETDAY,al

xor ah,ah
mov al, buf+2
sub al, 30h
mov bx,10
imul bx

mov bl,SETDAY
add al,bl
mov SETDAY,al

;get setmounth var
mov al, buf+6
sub al, 30h
mov SETMOUNTH,al

xor ah,ah
mov al, buf+5
sub al, 30h
mov bx,10
imul bx

mov bl,SETMOUNTH
add al,bl
mov SETMOUNTH,al

;get setyear var ; 8 9 10 11
mov al, buf+11
sub al, 30h
xor ah, ah
mov SETYEAR, ax

xor ah,ah
mov al, buf+10
sub al, 30h
mov bx,10
imul bx

mov bx,SETYEAR
add ax,bx
mov SETYEAR,ax

xor ah,ah
mov al, buf+9
sub al, 30h
mov bx,100
imul bx

mov bx,SETYEAR
add ax,bx
mov SETYEAR,ax

xor ah,ah
mov al, buf+8
sub al, 30h
mov bx, 1000
imul bx

mov bx,SETYEAR
add ax,bx
mov SETYEAR,ax

;prepare to set date

mov cx, SETYEAR
mov dh, SETMOUNTH
mov dl, SETDAY

;try set date

mov ah, 2Bh
int 21h

;say result

cmp al,0
je @success

mov ah,09h
lea dx, failStr
int 21h

jmp @cnt
@success:

mov ah,09h
lea dx, successStr
int 21h

@cnt:

mov ah,09h
lea dx, newStr
int 21h

mov ah,09h
lea dx, currentDateInviteStr
int 21h
CALL PRINTDATE

ret
main endp

PRINTDATE proc near

;get date
xor al,al
mov ah,2Ah
int 21h

;save data of date
mov PARSEDAY, dl
mov PARSEMOUNTH, dh
mov PARSEYEAR, cx

;get day
xor ax,ax
mov al, PARSEDAY
mov bx, 10

cwd
idiv bx

mov bx,dx

mov dx,ax
add dl,30h
mov ah,02h
int 21h

mov dx,bx
add dx,30h
mov ah,02h
int 21h

mov dl, 2EH
mov ah, 02H
int 21h

;get mounth
xor ax,ax
mov al, PARSEMOUNTH
mov bx, 10

cwd
idiv bx

mov bx,dx

mov dx,ax
add dl,30h
mov ah,02h
int 21h

mov dx,bx
add dx,30h
mov ah,02h
int 21h

mov dl, 2EH
mov ah, 02H
int 21h

;get year
xor ax,ax
mov ax, PARSEYEAR
mov bx, 1000

cwd
idiv bx

mov TMPYEAR, dx

mov dx,ax
add dl,30h
mov ah,02h
int 21h

xor ax,ax
mov ax, TMPYEAR
mov bx, 100

cwd
idiv bx

mov TMPYEAR, dx

mov dx,ax
add dl,30h
mov ah,02h
int 21h

xor ax,ax
mov ax, TMPYEAR
mov bx, 10

cwd
idiv bx

mov bx,dx

mov dx,ax
add dl,30h
mov ah,02h
int 21h

mov dx,bx
add dx,30h
mov ah,02h
int 21h
ret
PRINTDATE endp

CODE ends
end begin