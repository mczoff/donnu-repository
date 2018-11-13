.686p
.model flat, stdcall
option casemap:none

includelib C:\masm32\ShLwApi.Lib

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

EditClassName1 db "edit",0 ; имя класса поля редактирования
EditText1 db "edit1z",0 ; выводимый в поле текст

hwndEdit1 DWORD ?

EditClassName2 db "edit",0 ; имя класса поля редактирования
EditText2 db "edit2z",0 ; выводимый в поле текст

hwndEdit2 DWORD ?

EditID equ 2
ES_LEFT equ 0h
ES_AUTOHSCROLL equ 80h

StaticClassName db "edit",0 ; имя класса статического текста
StaticText db "My First Static",0 ; выводимый текст

hwndStatic DWORD ?
StaticID equ 3
SS_CENTER equ 1h

ButtonClassName db "button",0 ; имя класса кнопки
ButtonText db "CALCULATE",0 ; надпись на кнопке
ButtonID equ 1

hwndCalcButton DWORD ?

BS_DEFPUSHBUTTON equ 1h
WS_EX_CLIENTEDGE equ 0200h
BN_CLICKED equ 0

hwndButton DWORD ?

ClassName db "SimpleWinClass",0

AppName db "МОЯ ЛАБОРАТОРНАЯ",0

hInstance dd 00000000h

CommandLine dd 00000000h
;4. Определяем константы
.const
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
invoke CreateSolidBrush,0FFFFFFh ;0FFFFFFh 
mov wc.hbrBackground,eax
mov wc.lpszMenuName,0
mov wc.lpszClassName,OFFSET ClassName
invoke LoadIconA,0,IDI_APPLICATION
mov wc.hIcon,eax
mov wc.hIconSm,eax
invoke LoadCursorA,0,IDC_ARROW
mov wc.hCursor,eax
invoke RegisterClassExA, addr wc

invoke CreateWindowExA,0,ADDR ClassName, ADDR AppName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 275, 300, 0, 0, hInst,0
mov hwnd,eax

invoke ShowWindow, hwnd,SW_SHOWNORMAL

invoke UpdateWindow, hwnd```````````````````````````````````````````````````

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

.ELSEIF wMsg==WM_CREATE
	invoke CreateWindowExA, WS_EX_CLIENTEDGE,ADDR EditClassName1, 0 , WS_CHILD or WS_VISIBLE or WS_BORDER or ES_LEFT or ES_AUTOHSCROLL,50, 50, 70, 20, hWnd, EditID, hInstance, 0
	mov hwndEdit1, eax

	invoke CreateWindowExA, WS_EX_CLIENTEDGE,ADDR EditClassName2, 0 , WS_CHILD or WS_VISIBLE or WS_BORDER or ES_LEFT or ES_AUTOHSCROLL,150, 50, 70, 20, hWnd, EditID, hInstance, 0
	mov hwndEdit2, eax

	invoke CreateWindowExA, 0, ADDR StaticClassName, 0, WS_CHILD or WS_VISIBLE or SS_CENTER, 50, 180, 170, 20, hWnd, StaticID, hInstance, 0
	mov hwndStatic, eax

	invoke CreateWindowExA,0, ADDR ButtonClassName,ADDR ButtonText,WS_CHILD or WS_VISIBLE or BS_DEFPUSHBUTTON, 50, 100, 175, 25, hWnd, ButtonID, hInstance,0
	mov hwndButton, eax

.ELSEIF wMsg == WM_COMMAND
	mov eax, wParam
	.IF lParam != 0 ; выбран элемент управления
		.IF ax == ButtonID ; дескриптор кнопки
			shr eax,16
			.IF ax==BN_CLICKED ; нажата кнопка
				invoke GetWindowTextA, hwndEdit1, ADDR buffer, 10

				invoke StrToIntA, ADDR buffer
				push eax

				invoke GetWindowTextA, hwndEdit2, ADDR buffer, 10
				invoke StrToIntA, ADDR buffer
				mov ebx, eax
				pop eax
				
				;eax - 1, ebx - 2

				cmp     eax,0
						jge     @mNNegA
						neg     eax
				@mNNegA:
						cmp     ebx,0
						jge     @mNNegB
						neg     ebx
				@mNNegB:
 
				@mMain:
						cmp     eax,ebx
						jge     @mAGEB
						xchg    eax,ebx
				@mAGEB:
 
						cmp     ebx,0
						je      @mEx
 
						sub     eax,ebx
						jmp     @mMain
				@mEx:
				;

				invoke wsprintfA, addr buffer, addr format, eax
				invoke SetWindowTextA, hwndStatic, addr buffer
			.ENDIF
		.ENDIF
	.ENDIF

.ELSE
	invoke DefWindowProcA,hWnd,wMsg,wParam,lParam
	ret
.ENDIF

xor eax,eax
ret

WndProc endp
end start