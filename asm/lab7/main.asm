.686p
.model flat, stdcall
option casemap:none


wsprintfA PROTO C :VARARG
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
GetWindowTextA PROTO STDCALL :DWORD, :DWORD, :DWORD
SetWindowTextA PROTO STDCALL :DWORD, :DWORD
MessageBoxA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD 
StrToIntA PROTO STDCALL :DWORD
IntToStrA PROTO STDCALL :DWORD
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
buffer db 128 dup(0)
format db "%d",0

IconName db "ICON_MAIN",0
MenuName db 'MyMenu',0

BS_DEFPUSHBUTTON equ 1h
WS_EX_CLIENTEDGE equ 0200h
BN_CLICKED equ 0

hwndButton DWORD ?

ClassName db "SimpleWinClass",0
ClassNameS1 db "S1Class",0
AppName db "МОЯ ЛАБОРАТОРНАЯ",0

AppNameSix db "МОЯ ЛАБОРАТОРНАЯ 6",0
AppNameFive db "МОЯ ЛАБОРАТОРНАЯ 5",0

hInstance dd 00000000h
CommandLine dd 00000000h

HelpText db "Я делал это глубокой ночью поэтому я не могу ничего придумать изящного",0
SixLabText db "Вычисление наибольшего делителя двух целых чисел.",0
FiveLabText db "Реализовать изменение текста заголовка окна на заданный текст по двойному щелчку правой кнопки в клиентской области окна Обратную замену заголовка осуществить по нажатию клавиши F1.",0

hwndS1 dd ?
hwndS2 dd ?

EditClassNameS1 db "edit",0 ; имя класса поля редактирования
EditTextS1 db "My First Edit",0 ; выводимый в поле текст
hwndEditS1 dd ?

EditClassNameS2 db "edit",0 ; имя класса поля редактирования
EditTextS2 db "My First Edit",0 ; выводимый в поле текст
hwndEditS2 dd ?

.const

WM_CLOSE equ 10h
ES_LEFT equ 0h
ES_AUTOHSCROLL equ 80h
IDM_OPEN equ 101
IDM_T1 equ 103
IDM_T2 equ 104
IDM_S1 equ 105
IDM_S2 equ 106
IDM_HELP equ 111
IDM_EXIT equ 112
EditID equ 2
MB_OK equ 0
WM_CREATE equ 1h
WM_DESTROY equ 2h
WM_KEYDOWN equ 100h
WM_COMMAND equ 0111h
WS_BORDER equ 0800000h
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
WS_CHILD equ 40000000h
WS_VISIBLE equ 10000000h
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

WinMain proc hInst:DWORD ,hPrevInst:DWORD, CmdLine:DWORD, CmdShow:DWORD
LOCAL wc:WNDCLASSEXA
LOCAL wc1:WNDCLASSEXA
LOCAL wc2:WNDCLASSEXA
LOCAL msg:MSG
LOCAL hwnd:DWORD

;---------------------------------------

mov wc2.cbSize,SIZEOF WNDCLASSEXA
mov wc2.style, CS_HREDRAW or CS_VREDRAW or CS_DBLCLKS
mov wc2.lpfnWndProc, OFFSET WndProcS2
mov wc2.cbClsExtra,0
mov wc2.cbWndExtra,0
push hInst
pop wc2.hInstance
invoke CreateSolidBrush,0FFFFFFh ;0FFFFFFh 
mov wc2.hbrBackground,eax
mov wc2.lpszMenuName, 0
mov wc2.lpszClassName, OFFSET ClassNameS1
invoke LoadIconA,hInst, OFFSET IconName
mov wc2.hIcon,eax
mov wc2.hIconSm,eax
invoke LoadCursorA,0,IDC_ARROW
mov wc2.hCursor,eax
invoke RegisterClassExA, addr wc2

;---------------------------------------

mov wc1.cbSize,SIZEOF WNDCLASSEXA
mov wc1.style, CS_HREDRAW or CS_VREDRAW or CS_DBLCLKS
mov wc1.lpfnWndProc, OFFSET WndProcS1
mov wc1.cbClsExtra,0
mov wc1.cbWndExtra,0
push hInst
pop wc1.hInstance
invoke CreateSolidBrush,0FFFFFFh ;0FFFFFFh 
mov wc1.hbrBackground,eax
mov wc1.lpszMenuName, 0
mov wc1.lpszClassName, OFFSET ClassNameS1
invoke LoadIconA,hInst, OFFSET IconName
mov wc1.hIcon,eax
mov wc1.hIconSm,eax
invoke LoadCursorA,0,IDC_ARROW
mov wc1.hCursor,eax
invoke RegisterClassExA, addr wc1

;---------------------------------------

mov wc.cbSize,SIZEOF WNDCLASSEXA
mov wc.style, CS_HREDRAW or CS_VREDRAW or CS_DBLCLKS
mov wc.lpfnWndProc, OFFSET WndProc
mov wc.cbClsExtra,0
mov wc.cbWndExtra,0
push hInst
pop wc.hInstance
invoke CreateSolidBrush,0FFFFFFh ;0FFFFFFh 
mov wc.hbrBackground,eax
mov wc.lpszMenuName,OFFSET MenuName
mov wc.lpszClassName, OFFSET ClassName
invoke LoadIconA,hInst, OFFSET IconName
mov wc.hIcon,eax
mov wc.hIconSm,eax
invoke LoadCursorA,0,IDC_ARROW
mov wc.hCursor,eax
invoke RegisterClassExA, addr wc

;---------------------------------------
invoke CreateWindowExA,0,ADDR ClassName, ADDR AppName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 400, 300, 0, 0, hInst,0
mov hwnd,eax

invoke CreateWindowExA,0, ADDR ClassNameS1, ADDR AppNameFive, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 600, 600, 0, 0, hInst,0
mov hwndS1,eax

invoke CreateWindowExA,0, ADDR ClassNameS1, ADDR AppNameSix, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 600, 600, 0, 0, hInst,0
mov hwndS2,eax

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

WndProc proc hWnd:DWORD, wMsg:DWORD, wParam:DWORD, lParam:DWORD

.IF wMsg==WM_DESTROY
	invoke PostQuitMessage,0

.ELSEIF wMsg==WM_RBUTTONDBLCLK
	invoke SetWindowTextA, hWnd, addr AppName

.ELSEIF wMsg == WM_COMMAND
	mov eax,wParam
	.IF lParam == 0 
		.IF ax == IDM_HELP 
			invoke MessageBoxA,0, ADDR HelpText, ADDR AppName, MB_OK
		.ELSEIF ax == IDM_T1
			invoke MessageBoxA,0, ADDR FiveLabText, ADDR AppName, MB_OK
		.ELSEIF ax == IDM_T2 
			invoke MessageBoxA,0, ADDR SixLabText, ADDR AppName, MB_OK
		.ELSEIF ax == IDM_S1
			invoke ShowWindow, hwndS1, SW_SHOWNORMAL
		.ELSEIF ax == IDM_S2
			invoke ShowWindow, hwndS2, SW_SHOWNORMAL
		.ELSEIF ax == IDM_EXIT
			invoke ExitProcess, 0 
		.ENDIF

	.ENDIF

.ELSE
	invoke DefWindowProcA,hWnd,wMsg,wParam,lParam
	ret
.ENDIF

xor eax,eax
ret
WndProc endp

WndProcS1 proc hWnd:DWORD, wMsg:DWORD, wParam:DWORD, lParam:DWORD

.IF wMsg==WM_DESTROY
	invoke PostQuitMessage,0
.ELSEIF wMsg==WM_CREATE
	invoke CreateWindowExA, WS_EX_CLIENTEDGE, ADDR EditClassNameS1, 0 , WS_CHILD or WS_VISIBLE or WS_BORDER or ES_LEFT or ES_AUTOHSCROLL, 1, 1, 550, 550, hWnd, EditID, hInstance, 0
	mov hwndEditS1, eax
.ELSEIF wMsg == WM_CLOSE
	invoke ShowWindow, hWnd, 0
.ELSE
	invoke DefWindowProcA,hWnd,wMsg,wParam,lParam
	ret
.ENDIF

xor eax,eax
ret
WndProcS1 endp

WndProcS2 proc hWnd:DWORD, wMsg:DWORD, wParam:DWORD, lParam:DWORD

.IF wMsg==WM_DESTROY
	invoke PostQuitMessage,0
.ELSEIF wMsg==WM_CREATE
	invoke CreateWindowExA, WS_EX_CLIENTEDGE, ADDR EditClassNameS2, 0 , WS_CHILD or WS_VISIBLE or WS_BORDER or ES_LEFT or ES_AUTOHSCROLL, 1, 1, 550, 550, hWnd, EditID, hInstance, 0
	mov hwndEditS2, eax
.ELSEIF wMsg == WM_CLOSE
	invoke ShowWindow, hWnd, 0
.ELSE
	invoke DefWindowProcA,hWnd,wMsg,wParam,lParam
	ret
.ENDIF

xor eax,eax
ret
WndProcS2 endp

end start