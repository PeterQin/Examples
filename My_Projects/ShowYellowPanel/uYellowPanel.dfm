object frmYellowPanel: TfrmYellowPanel
  Left = 284
  Top = 167
  Width = 613
  Height = 379
  Caption = 'frmYellowPanel'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object pnlY: TPanel
    Left = 176
    Top = 0
    Width = 393
    Height = 100
    Caption = 'pnlY'
    Color = clYellow
    TabOrder = 0
  end
  object btnShowPro: TButton
    Left = 16
    Top = 120
    Width = 75
    Height = 25
    Caption = 'btnShowPro'
    TabOrder = 1
    OnClick = btnShowProClick
  end
  object btnHide: TButton
    Left = 120
    Top = 120
    Width = 75
    Height = 25
    Caption = 'btnHide'
    TabOrder = 2
    OnClick = btnHideClick
  end
  object btnWinCreateThread: TButton
    Left = 16
    Top = 176
    Width = 129
    Height = 25
    Caption = 'btnWinCreateThread'
    TabOrder = 3
    OnClick = btnWinCreateThreadClick
  end
  object btnThread: TButton
    Left = 16
    Top = 232
    Width = 75
    Height = 25
    Caption = 'btnThread'
    TabOrder = 4
    OnClick = btnThreadClick
  end
  object btnClearNo: TButton
    Left = 120
    Top = 232
    Width = 75
    Height = 25
    Caption = 'btnClearNo'
    TabOrder = 5
    OnClick = btnClearNoClick
  end
  object btnWinThreadShow: TButton
    Left = 216
    Top = 120
    Width = 137
    Height = 25
    Caption = 'btnWinThreadShow'
    TabOrder = 6
    OnClick = btnWinThreadShowClick
  end
  object btnChangeText: TButton
    Left = 16
    Top = 88
    Width = 97
    Height = 25
    Caption = 'btnChangeText'
    TabOrder = 7
    OnClick = btnChangeTextClick
  end
  object btnThreadShow: TButton
    Left = 376
    Top = 120
    Width = 129
    Height = 25
    Caption = 'btnThreadShow'
    TabOrder = 8
    OnClick = btnThreadShowClick
  end
  object btnApp: TButton
    Left = 16
    Top = 56
    Width = 75
    Height = 25
    Caption = 'btnApp'
    TabOrder = 9
    OnClick = btnAppClick
  end
end
