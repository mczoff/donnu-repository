.686p
.model flat, stdcall
option casemap : none

ExitProcess PROTO STDCALL :DWORD 
MessageBoxA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD 
wsprintfA PROTO C :VARARG

.data
TitleMsg db 'Second lab on masm',0

format db '(1970 - 1935) / 5 * 5 - 5 + 548 = %d', 10, 13, '((2210 - 210) / ( 29 + 31 - 10)) + ((1910 - 810) / 100) * 2 = %d', 0
buffer db 128 dup(0)

NUMBER_1 dd 0
NUMBER_2 dd 0
.const
MB_OK equ 0

.code
start:

;first
mov eax, 1970
sub eax, 1935

cdq	

mov ebx, 5
idiv ebx

mov edx, 5
imul edx

sub eax, 5
add eax, 548

;second
mov NUMBER_1, eax

mov eax, 2210
sub eax,210

mov ebx, 29
add ebx, 31
sub ebx, 10

cdq
idiv ebx

mov NUMBER_2, eax
mov eax, 1910
sub eax, 810

mov ebx, 100

cdq
idiv ebx

mov ebx, 2
imul ebx

add eax, NUMBER_2
mov NUMBER_2, eax

;answer
invoke wsprintfA, addr buffer, addr format, NUMBER_1, NUMBER_2
invoke MessageBoxA, 0, addr buffer, addr TitleMsg, 0
invoke ExitProcess, 0

end start