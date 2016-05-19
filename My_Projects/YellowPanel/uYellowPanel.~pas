interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
    TForm1 = class(TForm)
    pnlYellow: TPanel;
    btnShow: TButton;
    btnHide: TButton;
    btnThread: TButton;
    btnFree: TButton;
    btnNo: TButton;
    btnAPI: TButton;
    btnTThread: TButton;
  

  private
    { Private declarations }
  protected 
    procedure Execute; override;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;


implementation

{$R *.dfm}

function MyThreadFunc(P:pointer):Longint;stdcall;
begin

end;

procedure TForm1.btnShowClick(Sender: TObject);
var
   OrgH, HStamp, i : Integer;

begin
   pnlYellow.Visible := True;
   OrgH := pnlYellow.Height;
   HStamp := OrgH div 10;
   pnlYellow.Height := 1;
   for i := 1 to 10 do
   begin
      pnlYellow.Height := pnlYellow.Height + HStamp;
      Sleep(30);
      Application.ProcessMessages;
   end;
   pnlYellow.Height := OrgH;

end;

procedure TForm1.btnHideClick(Sender: TObject);
begin
  pnlYellow.Visible := False;
end;

procedure TForm1.btnThreadClick(Sender: TObject);
var
   hThread:Thandle;
   ThreadID:DWord;
begin
  hthread:=CreateThread(nil,0,@MyThreadfunc,nil,0,ThreadID);
  if hThread=0 then
  messagebox(Handle,'DidnCreateaThread',nil,MB_OK);
end;

procedure TForm1.btnNoClick(Sender: TObject);
var 
  i: Integer; 
begin 
  for i := 0 to 300000 do
  begin
    Canvas.TextOut(10, 10, IntToStr(i)); 
  end; 
end;

function MyFun: Integer; stdcall;
var 
  i: Integer; 
begin
  for i := 0 to 300000 do
  begin 
    Form1.Canvas.Lock; 
    Form1.Canvas.TextOut(10, 10, IntToStr(i)); 
    Form1.Canvas.Unlock; 
  end;
  Result := 0; 
end;

procedure TForm1.btnAPIClick(Sender: TObject);
var
   ID : THandle;
begin
    CreateThread(nil, 0, @MyFun, nil, 0, ID); 
end;



procedure TForm1.btnShowClick(Sender: TObject);
begin

end;

end.
