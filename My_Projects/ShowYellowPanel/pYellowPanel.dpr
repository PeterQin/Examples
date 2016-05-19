program pYellowPanel;

uses
  Forms,
  uYellowPanel in 'uYellowPanel.pas' {frmYellowPanel};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmYellowPanel, frmYellowPanel);
  Application.Run;
end.
