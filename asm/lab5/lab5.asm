.686p
.model flat, stdcall
option casemap:none

GetModuleHandleA PROTO STDCALL :DWORD
LoadCursorA PROTO STDCALL :DWORD,:DWORD
LoadIconA PROTO STDCALL :DWORD,:DWORD
RegisterClassExA PROTO STDCALL :DWORD
CreateWindowExA PROTO STDCALL :DWORD,:DWORD, :DWORD, :DWORD,
:DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD
ShowWindow PROTO STDCALL :DWORD,:DWORD
UpdateWindow PROTO STDCALL :DWORD
GetMessageA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD
TranslateMessage PROTO STDCALL :DWORD
DispatchMessageA PROTO STDCALL :DWORD
DefWindowProcA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD
SetWindowTextA PROTO STDCALL :DWORD, :DWORD

PostQuitMessage PROTO STDCALL :DWORD
GetCommandLineA PROTO STDCALL
CreateSolidBrush PROTO STDCALL :DWORD
ExitProcess PROTO STDCALL :DWORD
WinMain PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD

POINT STRUCT
x DWORD ?
y DWORD ?
POINT ENDS

MSG STRUCT
hwnd DWORD ?
message DWORD ?
wParam DWORD ?
lParam DWORD ?
time DWORD ?
pt POINT <>
MSG ENDS

WNDCLASSEXA STRUCT
cbSize DWORD ?
style DWORD ?
lpfnWndProc DWORD ?
cbClsExtra DWORD ?
cbWndExtra DWORD ?
hInstance DWORD ?
hIcon DWORD ?
hCursor DWORD ?
hbrBackground DWORD ?
lpszMenuName DWORD ?
lpszClassName DWORD ?
hIconSm DWORD ?
WNDCLASSEXA ENDS

.data

ClassName db "SimpleWinClass",0

AppName db "Наше первое окно",0
AppNameENEMY db "Я изменился нажми на F1, чтобы я ушел",0

hInstance dd 00000000h

CommandLine dd 00000000h
;4. Определяем константы
.const
WM_DESTROY equ 2h
WM_KEYDOWN equ 100h
WM_RBUTTONDBLCLK equ 0206h
CS_DBLCLKS equ 8h
VK_ESCAPE equ 1Bh
VK_F1 equ 70h
IDI_APPLICATION equ 32512
IDC_ARROW equ 32512
SW_SHOWNORMAL equ 1
CS_HREDRAW equ 2h
CS_VREDRAW equ 1h
COLOR_BTNFACE equ 15
CW_USEDEFAULT equ 80000000h
WS_OVERLAPPED equ 0h
WS_CAPTION equ 0C00000h
WS_SYSMENU equ 80000h
WS_THICKFRAME equ 40000h
WS_MINIMIZEBOX equ 20000h
WS_MAXIMIZEBOX equ 10000h
WS_OVERLAPPEDWINDOW equ WS_OVERLAPPED OR WS_CAPTION OR WS_SYSMENU OR WS_THICKFRAME OR WS_MINIMIZEBOX OR WS_MAXIMIZEBOX
SW_SHOWDEFAULT equ 10
.code
start:
invoke GetModuleHandleA, 0
mov hInstance,eax
invoke GetCommandLineA
mov CommandLine,eax
invoke WinMain, hInstance, 0 , CommandLine, SW_SHOWDEFAULT
invoke ExitProcess,eax

WinMain proc hInst:DWORD ,hPrevInst:DWORD, CmdLine:DWORD,
CmdShow:DWORD

LOCAL wc:WNDCLASSEXA
LOCAL msg:MSG
LOCAL hwnd:DWORD
mov wc.cbSize,SIZEOF WNDCLASSEXA
mov wc.style, CS_HREDRAW or CS_VREDRAW or CS_DBLCLKS
mov wc.lpfnWndProc, OFFSET WndProc
mov wc.cbClsExtra,0
mov wc.cbWndExtra,0
push hInst
pop wc.hInstance
invoke CreateSolidBrush,00F14D73h
mov wc.hbrBackground,eax
mov wc.lpszMenuName,0
mov wc.lpszClassName,OFFSET ClassName
invoke LoadIconA,0,IDI_APPLICATION
mov wc.hIcon,eax
mov wc.hIconSm,eax
invoke LoadCursorA,0,IDC_ARROW
mov wc.hCursor,eax
invoke RegisterClassExA, addr wc

invoke CreateWindowExA,0,ADDR ClassName, ADDR AppName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,0,0, hInst,0
mov hwnd,eax

invoke ShowWindow, hwnd,SW_SHOWNORMAL

invoke UpdateWindow, hwnd

.WHILE 1

invoke GetMessageA, ADDR msg,0,0,0
.BREAK .IF (!eax)

invoke TranslateMessage, ADDR msg

invoke DispatchMessageA, ADDR msg
.ENDW
mov eax,msg.wParam
ret
WinMain endp


WndProc proc hWnd:DWORD, wMsg:DWORD, wParam:DWORD,
lParam:DWORD

.IF wMsg==WM_DESTROY
	invoke PostQuitMessage,0

.ELSEIF wMsg==WM_RBUTTONDBLCLK
	invoke SetWindowTextA, hWnd, addr AppNameENEMY

.ELSEIF wMsg==WM_KEYDOWN
	.IF wParam==VK_ESCAPE
		invoke PostQuitMessage, 0
	.ELSEIF wParam==VK_F1
		invoke SetWindowTextA, hWnd, addr AppName
	.ENDIF
.ELSE
	invoke DefWindowProcA,hWnd,wMsg,wParam,lParam
ret
.ENDIF

xor eax,eax
ret

WndProc endp
end start