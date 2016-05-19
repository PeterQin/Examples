unit uYellowPanel;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TfrmYellowPanel = class(TForm)
    pnlY: TPanel;
    btnShowPro: TButton;
    btnHide: TButton;
    btnWinCreateThread: TButton;
    btnThread: TButton;
    btnClearNo: TButton;
    btnWinThreadShow: TButton;
    btnChangeText: TButton;
    btnThreadShow: TButton;
    btnApp: TButton;
    procedure btnShowProClick(Sender: TObject);
    procedure btnHideClick(Sender: TObject);
    procedure btnWinCreateThreadClick(Sender: TObject);
    procedure btnThreadClick(Sender: TObject);
    procedure btnClearNoClick(Sender: TObject);
    procedure btnWinThreadShowClick(Sender: TObject);
    procedure btnChangeTextClick(Sender: TObject);
    procedure btnThreadShowClick(Sender: TObject);
    procedure btnAppClick(Sender: TObject);
  private
    { Private declarations }
  public
     procedure showw;
    { Public declarations }
  end;
  TMyThread = class(TThread)
  protected
    procedure Execute; override;
  end;
  TMyThreadShow = class(TThread)
  protected
      procedure Execute; override;
      procedure ShowWindowStep;
  end;
var
  frmYellowPanel: TfrmYellowPanel;

implementation

{$R *.dfm}

procedure TfrmYellowPanel.btnShowProClick(Sender: TObject);
var
  orgH, stepH, i : integer;
begin
   pnlY.Visible := True;
   orgH := pnlY.Height;
   stepH := orgH div 10;
   pnlY.Height := 0;
   for i:=1 to 10 do
   begin
      pnlY.Height := pnlY.Height + stepH;
      Application.ProcessMessages;
      sleep(50);
   end;
   pnlY.Height := orgH;
end;

procedure TfrmYellowPanel.btnHideClick(Sender: TObject);
begin
   pnlY.Visible := False;
end;

function MyFun(p: Pointer): Integer; stdcall;
var
  i: Integer;
begin
  for i := 0 to 200 do
  begin
    frmYellowPanel.Canvas.Lock;
    frmYellowPanel.Canvas.TextOut(10, 10, IntToStr(i));
    frmYellowPanel.Canvas.Unlock;
    Sleep(1);
  end;
  Result := 0;
end;

procedure TfrmYellowPanel.btnWinCreateThreadClick(Sender: TObject);
var
   ID : THandle;
begin
   CreateThread(nil,0,@MyFun,nil,0,ID);
end;

procedure TfrmYellowPanel.btnThreadClick(Sender: TObject);
begin
   TMyThread.Create(False); 
end;
procedure TMyThreadShow.ShowWindowStep;
var
  orgH, stepH, i : integer;
begin
   frmYellowPanel.pnlY.Visible := True;
   orgH := frmYellowPanel.pnlY.Height;
   stepH := orgH div 10;
   frmYellowPanel.pnlY.Height := 0;
   for i:=1 to 10 do
   begin
      frmYellowPanel.pnlY.Height := frmYellowPanel.pnlY.Height + stepH;
      //Application.ProcessMessages;
      sleep(50);
   end;
   frmYellowPanel.pnlY.Height := orgH;

end;
procedure TMyThread.Execute;
var
  i: Integer;
begin
  FreeOnTerminate := True; {这可以让线程执行完毕后随即释放}

end;

procedure TfrmYellowPanel.btnClearNoClick(Sender: TObject);
begin
   frmYellowPanel.Canvas.TextOut(10, 10, '       ');
end;

procedure TfrmYellowPanel.showw;
var
  orgH, stepH, i : integer;
begin
   frmYellowPanel.pnlY.Visible := True;
   orgH := frmYellowPanel.pnlY.Height;
   stepH := orgH div 10;
   frmYellowPanel.pnlY.Height := 0;
   for i:=1 to 10 do
   begin
      frmYellowPanel.pnlY.Height := frmYellowPanel.pnlY.Height + stepH;
      //Application.ProcessMessages;
      sleep(50);
   end;
   frmYellowPanel.pnlY.Height := orgH;

end;

function StepShow(p: Pointer): Integer; stdcall;
begin
   //synchronize(showw);
   Result := 0;
end;

procedure TfrmYellowPanel.btnWinThreadShowClick(Sender: TObject);
var
   ID : THandle;
begin
   CreateThread(nil,0,@StepShow,nil,0,ID);
end;

function ChangeText(p: Pointer): Integer; stdcall;
var
  i : integer;
begin
   for i:=1 to 100000 do
   begin
      frmYellowPanel.pnlY.Caption := IntToStr(i);
      Sleep(1);
   end;
   Result := 0;
end;

procedure TfrmYellowPanel.btnChangeTextClick(Sender: TObject);
var
   ID : THandle;
begin
   CreateThread(nil,0,@ChangeText,nil,0,ID);
end;


procedure TMyThreadShow.Execute;

begin
  FreeOnTerminate := True; {这可以让线程执行完毕后随即释放}
  synchronize(ShowWindowStep);
end;

procedure TfrmYellowPanel.btnThreadShowClick(Sender: TObject);
begin
   TMyThreadShow.Create(False);
end;

function windowh(p: Pointer): Integer; stdcall;
var
   i : Integer;
begin
    for i:=1 to 10000 do
    begin
       frmYellowPanel.Height := frmYellowPanel.Height + 2;
       Sleep(1);
       frmYellowPanel.Height := frmYellowPanel.Height - 2;
    end;
end;

procedure TfrmYellowPanel.btnAppClick(Sender: TObject);
var
   ID : THandle;
begin
   CreateThread(nil,0,@windowh,nil,0,ID);
end;

end.
