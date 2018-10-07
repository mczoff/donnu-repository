.686p
.model flat, stdcall
option casemap : none

ExitProcess PROTO STDCALL :DWORD 
MessageBoxA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD 
wsprintfA PROTO C :VARARG

.data
TitleMsg db 'Third lab on masm',0

format db 'First proc: %d | Second proc: %d', 0
buffer db 128 dup(0)

A dd 29
B dd 1
X dd 2
_X1 dd 21
_X2 dd 12
_A1 dd 20
_A2 dd -10

ANSWER_1 DD ?
ANSWER_2 DD ?
.const
MB_OK equ 0

.code
start:

mov eax, A
add eax, B
mov ebx, 10

cdq
idiv ebx

mov ebx,eax

push eax
push X
call FirstProc
add esp, 8

mov ANSWER_1, eax

mov eax, _A1
add eax, _A2
sub eax, 6

push offset ANSWER_2
push eax
call SecondProc
add esp, 8

invoke wsprintfA, addr buffer, addr format, ANSWER_1, ANSWER_2
invoke MessageBoxA, 0, addr buffer, addr TitleMsg, 0
invoke ExitProcess, 0

FirstProc proc 

pushad

mov eax, [esp + 4]
mov ebx, [esp + 8]

cmp eax, 0
jl @zero
cmp ebx, 0
je @one
jg @two

@two:
popad
mov eax,2
ret	

@one:
popad
mov eax,1
ret	

@zero:
popad
mov eax,0
ret	

FirstProc endp

SecondProc proc 

pushad

mov eax, [esp + 32 + 4]
mov edx, [esp + 32 + 8]

cmp eax, 0

jle @lessOrEqual

mov eax, 0
mov [edx], eax 

popad
ret
@lessOrEqual:

mov eax, 1
mov [edx], eax

popad
ret

SecondProc endp

end start
