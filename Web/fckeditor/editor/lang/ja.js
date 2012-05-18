/*
 * FCKeditor - The text editor for Internet - http://www.fckeditor.net
 * Copyright (C) 2003-2007 Frederico Caldeira Knabben
 *
 * == BEGIN LICENSE ==
 *
 * Licensed under the terms of any of the following licenses at your
 * choice:
 *
 *  - GNU General Public License Version 2 or later (the "GPL")
 *    http://www.gnu.org/licenses/gpl.html
 *
 *  - GNU Lesser General Public License Version 2.1 or later (the "LGPL")
 *    http://www.gnu.org/licenses/lgpl.html
 *
 *  - Mozilla Public License Version 1.1 or later (the "MPL")
 *    http://www.mozilla.org/MPL/MPL-1.1.html
 *
 * == END LICENSE ==
 *
 * Japanese language file.
 */

var FCKLang =
{
// Language direction : "ltr" (left to right) or "rtl" (right to left).
Dir					: "ltr",

ToolbarCollapse		: "ツールバーを隠す",
ToolbarExpand		: "ツールバーを表示",

// Toolbar Items and Context Menu
Save				: "保存",
NewPage				: "新しいページ",
Preview				: "プレビュー",
Cut					: "切り取り",
Copy				: "コピー",
Paste				: "貼り付け",
PasteText			: "プレーンテキスト貼り付け",
PasteWord			: "ワード文章から貼り付け",
Print				: "印刷",
SelectAll			: "すべて選択",
RemoveFormat		: "フォーマット削除",
InsertLinkLbl		: "リンク",
InsertLink			: "リンク挿入/編集",
RemoveLink			: "リンク削除",
Anchor				: "アンカー挿入/編集",
AnchorDelete		: "アンカー削除",
InsertImageLbl		: "イメージ",
InsertImage			: "イメージ挿入/編集",
InsertFlashLbl		: "Flash",
InsertFlash			: "Flash挿入/編集",
InsertTableLbl		: "テーブル",
InsertTable			: "テーブル挿入/編集",
InsertLineLbl		: "ライン",
InsertLine			: "横罫線",
InsertSpecialCharLbl: "特�文字",
InsertSpecialChar	: "特�文字挿入",
InsertSmileyLbl		: "絵文字",
InsertSmiley		: "絵文字挿入",
About				: "FCKeditorヘルプ",
Bold				: "太字",
Italic				: "斜体",
Underline			: "下線",
StrikeThrough		: "打ち消し線",
Subscript			: "添え字",
Superscript			: "上付き文字",
LeftJustify			: "左揃え",
CenterJustify		: "中�揃え",
RightJustify		: "右揃え",
BlockJustify		: "両端揃え",
DecreaseIndent		: "インデント解除",
IncreaseIndent		: "インデント",
Blockquote			: "ブロック引用",
Undo				: "元に戻す",
Redo				: "やり直し",
NumberedListLbl		: "�落番号",
NumberedList		: "�落番号�追加/削除",
BulletedListLbl		: "�条書き",
BulletedList		: "�条書き�追加/削除",
ShowTableBorders	: "テーブルボーダー表示",
ShowDetails			: "詳細表示",
Style				: "スタイル",
FontFormat			: "フォーマット",
Font				: "フォント",
FontSize			: "サイズ",
TextColor			: "テキスト色",
BGColor				: "背景色",
Source				: "ソース",
Find				: "検索",
Replace				: "�き換え",
SpellCheck			: "スペルチェック",
UniversalKeyboard	: "ユニバーサル・キーボード",
PageBreakLbl		: "改ページ",
PageBreak			: "改ページ挿入",

Form			: "フォーム",
Checkbox		: "チェックボックス",
RadioButton		: "ラジオボタン",
TextField		: "１行テキスト",
Textarea		: "テキストエリア",
HiddenField		: "不可視フィールド",
Button			: "ボタン",
SelectionField	: "選択フィールド",
ImageButton		: "画像ボタン",

FitWindow		: "エディタサイズを最大にします",
ShowBlocks		: "ブロック表示",

// Context Menu
EditLink			: "リンク編集",
CellCM				: "セル",
RowCM				: "行",
ColumnCM			: "カラム",
InsertRowAfter		: "列�後に挿入",
InsertRowBefore		: "列�前に挿入",
DeleteRows			: "行削除",
InsertColumnAfter	: "カラム�後に挿入",
InsertColumnBefore	: "カラム�前に挿入",
DeleteColumns		: "列削除",
InsertCellAfter		: "セル�後に挿入",
InsertCellBefore	: "セル�前に挿入",
DeleteCells			: "セル削除",
MergeCells			: "セル結合",
MergeRight			: "右に結合",
MergeDown			: "下に結合",
HorizontalSplitCell	: "セルを水平方向分割",
VerticalSplitCell	: "セルを垂直方向に分割",
TableDelete			: "テーブル削除",
CellProperties		: "セル プロパティ",
TableProperties		: "テーブル プロパティ",
ImageProperties		: "イメージ プロパティ",
FlashProperties		: "Flash プロパティ",

AnchorProp			: "アンカー プロパティ",
ButtonProp			: "ボタン プロパティ",
CheckboxProp		: "チェックボックス プロパティ",
HiddenFieldProp		: "不可視フィールド プロパティ",
RadioButtonProp		: "ラジオボタン プロパティ",
ImageButtonProp		: "画像ボタン プロパティ",
TextFieldProp		: "１行テキスト プロパティ",
SelectionFieldProp	: "選択フィールド プロパティ",
TextareaProp		: "テキストエリア プロパティ",
FormProp			: "フォーム プロパティ",

FontFormats			: "標準;書式付き;アドレス;見出し 1;見出し 2;見出し 3;見出し 4;見出し 5;見出し 6;標準 (DIV)",

// Alerts and Messages
ProcessingXHTML		: "XHTML処理中. しばらくお待ちください...",
Done				: "�了",
PasteWordConfirm	: "貼り付けを行うテキストは、ワード文章からコピーされようとしています。貼り付ける前にクリーニングを行いますか？",
NotCompatiblePaste	: "こ�コマンドはインターネット・エクスプローラーバージョン5.5以上で利用可能です。クリーニングしないで貼り付けを行いますか？",
UnknownToolbarItem	: "未知�ツールバー項� \"%1\"",
UnknownCommand		: "未知�コマンド名 \"%1\"",
NotImplemented		: "コマンドはインプリメントされませんでした。",
UnknownToolbarSet	: "ツールバー設� \"%1\" 存在しません。",
NoActiveX			: "エラー、警告メッセージなどが発生した場合、ブラウザー�セキュリティ設�によりエディタ�いくつか�機能が制限されている可能性があります。セキュリティ設��オプションで\"ActiveXコントロールとプラグイン��行\"を有効にするにしてください。",
BrowseServerBlocked : "サーバーブラウザーを開くことができませんでした。ポップアップ・ブロック機能が無効になっているか確認してください。",
DialogBlocked		: "ダイアログウィンドウを開くことができませんでした。ポップアップ・ブロック機能が無効になっているか確認してください。",

// Dialogs
DlgBtnOK			: "OK",
DlgBtnCancel		: "キャンセル",
DlgBtnClose			: "閉じる",
DlgBtnBrowseServer	: "サーバーブラウザー",
DlgAdvancedTag		: "高度な設�",
DlgOpOther			: "<そ�他>",
DlgInfoTab			: "情報",
DlgAlertUrl			: "URLを挿入してください",

// General Dialogs Labels
DlgGenNotSet		: "<なし>",
DlgGenId			: "Id",
DlgGenLangDir		: "文字表記�方向",
DlgGenLangDirLtr	: "左から右 (LTR)",
DlgGenLangDirRtl	: "右から左 (RTL)",
DlgGenLangCode		: "言語コード",
DlgGenAccessKey		: "アクセスキー",
DlgGenName			: "Name属性",
DlgGenTabIndex		: "タブインデックス",
DlgGenLongDescr		: "longdesc属性(長文説明)",
DlgGenClass			: "スタイルシートクラス",
DlgGenTitle			: "Title属性",
DlgGenContType		: "Content Type属性",
DlgGenLinkCharset	: "リンクcharset属性",
DlgGenStyle			: "スタイルシート",

// Image Dialog
DlgImgTitle			: "イメージ プロパティ",
DlgImgInfoTab		: "イメージ 情報",
DlgImgBtnUpload		: "サーバーに送信",
DlgImgURL			: "URL",
DlgImgUpload		: "アップロード",
DlgImgAlt			: "代替テキスト",
DlgImgWidth			: "幅",
DlgImgHeight		: "高さ",
DlgImgLockRatio		: "ロック比率",
DlgBtnResetSize		: "サイズリセット",
DlgImgBorder		: "ボーダー",
DlgImgHSpace		: "横間隔",
DlgImgVSpace		: "縦間隔",
DlgImgAlign			: "行揃え",
DlgImgAlignLeft		: "左",
DlgImgAlignAbsBottom: "下部(絶対的)",
DlgImgAlignAbsMiddle: "中�(絶対的)",
DlgImgAlignBaseline	: "ベースライン",
DlgImgAlignBottom	: "下",
DlgImgAlignMiddle	: "中�",
DlgImgAlignRight	: "右",
DlgImgAlignTextTop	: "テキスト上部",
DlgImgAlignTop		: "上",
DlgImgPreview		: "プレビュー",
DlgImgAlertUrl		: "イメージ�URLを入力してください。",
DlgImgLinkTab		: "リンク",

// Flash Dialog
DlgFlashTitle		: "Flash プロパティ",
DlgFlashChkPlay		: "再生",
DlgFlashChkLoop		: "ループ再生",
DlgFlashChkMenu		: "Flashメニュー可能",
DlgFlashScale		: "拡大�小設�",
DlgFlashScaleAll	: "すべて表示",
DlgFlashScaleNoBorder	: "外が見えない様に拡大",
DlgFlashScaleFit	: "上下左右にフィット",

// Link Dialog
DlgLnkWindowTitle	: "ハイパーリンク",
DlgLnkInfoTab		: "ハイパーリンク 情報",
DlgLnkTargetTab		: "ターゲット",

DlgLnkType			: "リンクタイプ",
DlgLnkTypeURL		: "URL",
DlgLnkTypeAnchor	: "こ�ページ�アンカー",
DlgLnkTypeEMail		: "E-Mail",
DlgLnkProto			: "プロトコル",
DlgLnkProtoOther	: "<そ�他>",
DlgLnkURL			: "URL",
DlgLnkAnchorSel		: "アンカーを選択",
DlgLnkAnchorByName	: "アンカー名",
DlgLnkAnchorById	: "エレメントID",
DlgLnkNoAnchors		: "(ドキュメントにおいて利用可能なアンカーはありません。)",
DlgLnkEMail			: "E-Mail アドレス",
DlgLnkEMailSubject	: "件名",
DlgLnkEMailBody		: "本文",
DlgLnkUpload		: "アップロード",
DlgLnkBtnUpload		: "サーバーに送信",

DlgLnkTarget		: "ターゲット",
DlgLnkTargetFrame	: "<フレーム>",
DlgLnkTargetPopup	: "<ポップアップウィンドウ>",
DlgLnkTargetBlank	: "新しいウィンドウ (_blank)",
DlgLnkTargetParent	: "親ウィンドウ (_parent)",
DlgLnkTargetSelf	: "同じウィンドウ (_self)",
DlgLnkTargetTop		: "最上位ウィンドウ (_top)",
DlgLnkTargetFrameName	: "�的�フレーム名",
DlgLnkPopWinName	: "ポップアップウィンドウ名",
DlgLnkPopWinFeat	: "ポップアップウィンドウ特徴",
DlgLnkPopResize		: "リサイズ可能",
DlgLnkPopLocation	: "ロケーションバー",
DlgLnkPopMenu		: "メニューバー",
DlgLnkPopScroll		: "スクロールバー",
DlgLnkPopStatus		: "ステータスバー",
DlgLnkPopToolbar	: "ツールバー",
DlgLnkPopFullScrn	: "全画面モード(IE)",
DlgLnkPopDependent	: "開いたウィンドウに連動して閉じる (Netscape)",
DlgLnkPopWidth		: "幅",
DlgLnkPopHeight		: "高さ",
DlgLnkPopLeft		: "左端から�座標で指�",
DlgLnkPopTop		: "上端から�座標で指�",

DlnLnkMsgNoUrl		: "リンクURLを入力してください。",
DlnLnkMsgNoEMail	: "メールアドレスを入力してください。",
DlnLnkMsgNoAnchor	: "アンカーを選択してください。",
DlnLnkMsgInvPopName	: "ポップ・アップ名は英字で始まる文字で指�してくだい。ポップ・アップ名にスペースは含めません",

// Color Dialog
DlgColorTitle		: "色選択",
DlgColorBtnClear	: "クリア",
DlgColorHighlight	: "ハイライト",
DlgColorSelected	: "選択色",

// Smiley Dialog
DlgSmileyTitle		: "顔文字挿入",

// Special Character Dialog
DlgSpecialCharTitle	: "特�文字選択",

// Table Dialog
DlgTableTitle		: "テーブル プロパティ",
DlgTableRows		: "行",
DlgTableColumns		: "列",
DlgTableBorder		: "ボーダーサイズ",
DlgTableAlign		: "キャプション�整列",
DlgTableAlignNotSet	: "<なし>",
DlgTableAlignLeft	: "左",
DlgTableAlignCenter	: "中�",
DlgTableAlignRight	: "右",
DlgTableWidth		: "テーブル幅",
DlgTableWidthPx		: "ピクセル",
DlgTableWidthPc		: "パーセント",
DlgTableHeight		: "テーブル高さ",
DlgTableCellSpace	: "セル内余白",
DlgTableCellPad		: "セル内間隔",
DlgTableCaption		: "ｷｬﾌﾟｼ�ﾝ",
DlgTableSummary		: "テーブル�的/構造",

// Table Cell Dialog
DlgCellTitle		: "セル プロパティ",
DlgCellWidth		: "幅",
DlgCellWidthPx		: "ピクセル",
DlgCellWidthPc		: "パーセント",
DlgCellHeight		: "高さ",
DlgCellWordWrap		: "折り返し",
DlgCellWordWrapNotSet	: "<なし>",
DlgCellWordWrapYes	: "Yes",
DlgCellWordWrapNo	: "No",
DlgCellHorAlign		: "セル横�整列",
DlgCellHorAlignNotSet	: "<なし>",
DlgCellHorAlignLeft	: "左",
DlgCellHorAlignCenter	: "中�",
DlgCellHorAlignRight: "右",
DlgCellVerAlign		: "セル縦�整列",
DlgCellVerAlignNotSet	: "<なし>",
DlgCellVerAlignTop	: "上",
DlgCellVerAlignMiddle	: "中�",
DlgCellVerAlignBottom	: "下",
DlgCellVerAlignBaseline	: "ベースライン",
DlgCellRowSpan		: "縦幅(行数)",
DlgCellCollSpan		: "横幅(列数)",
DlgCellBackColor	: "背景色",
DlgCellBorderColor	: "ボーダーカラー",
DlgCellBtnSelect	: "選択...",

// Find and Replace Dialog
DlgFindAndReplaceTitle	: "検索して�換",

// Find Dialog
DlgFindTitle		: "検索",
DlgFindFindBtn		: "検索",
DlgFindNotFoundMsg	: "指�された文字列は見つかりませんでした。",

// Replace Dialog
DlgReplaceTitle			: "�き換え",
DlgReplaceFindLbl		: "検索する文字列:",
DlgReplaceReplaceLbl	: "�換えする文字列:",
DlgReplaceCaseChk		: "部分一致",
DlgReplaceReplaceBtn	: "�換え",
DlgReplaceReplAllBtn	: "すべて�換え",
DlgReplaceWordChk		: "単語単位で一致",

// Paste Operations / Dialog
PasteErrorCut	: "ブラウザー�セキュリティ設�によりエディタ�切り取り操作が自動で�行することができません。�行するには手動でキーボード�(Ctrl+X)を使用してください。",
PasteErrorCopy	: "ブラウザー�セキュリティ設�によりエディタ�コピー操作が自動で�行することができません。�行するには手動でキーボード�(Ctrl+C)を使用してください。",

PasteAsText		: "プレーンテキスト貼り付け",
PasteFromWord	: "ワード文章から貼り付け",

DlgPasteMsg2	: "キーボード(<STRONG>Ctrl+V</STRONG>)を使用して、次�入力エリア内で貼って、<STRONG>OK</STRONG>を押してください。",
DlgPasteSec		: "ブラウザ�セキュリティ設�により、エディタはクリップボード・データに直接アクセスすることができません。こ�ウィンドウは貼り付け操作を行う度に表示されます。",
DlgPasteIgnoreFont		: "Fontタグ�Face属性を無視します。",
DlgPasteRemoveStyles	: "スタイル�義を削除します。",
DlgPasteCleanBox		: "入力エリアクリア",

// Color Picker
ColorAutomatic	: "自動",
ColorMoreColors	: "そ�他�色...",

// Document Properties
DocProps		: "文書 プロパティ",

// Anchor Dialog
DlgAnchorTitle		: "アンカー プロパティ",
DlgAnchorName		: "アンカー名",
DlgAnchorErrorName	: "アンカー名を必ず入力してください。",

// Speller Pages Dialog
DlgSpellNotInDic		: "辞書にありません",
DlgSpellChangeTo		: "変更",
DlgSpellBtnIgnore		: "無視",
DlgSpellBtnIgnoreAll	: "すべて無視",
DlgSpellBtnReplace		: "�換",
DlgSpellBtnReplaceAll	: "すべて�換",
DlgSpellBtnUndo			: "やり直し",
DlgSpellNoSuggestions	: "- 該当なし -",
DlgSpellProgress		: "スペルチェック処理中...",
DlgSpellNoMispell		: "スペルチェック�了: スペル�誤りはありませんでした",
DlgSpellNoChanges		: "スペルチェック�了: 語句は変更されませんでした",
DlgSpellOneChange		: "スペルチェック�了: １語句変更されました",
DlgSpellManyChanges		: "スペルチェック�了: %1 語句変更されました",

IeSpellDownload			: "スペルチェッカーがインストールされていません。今すぐダウンロードしますか?",

// Button Dialog
DlgButtonText		: "テキスト (値)",
DlgButtonType		: "タイプ",
DlgButtonTypeBtn	: "ボタン",
DlgButtonTypeSbm	: "送信",
DlgButtonTypeRst	: "リセット",

// Checkbox and Radio Button Dialogs
DlgCheckboxName		: "名前",
DlgCheckboxValue	: "値",
DlgCheckboxSelected	: "選択済み",

// Form Dialog
DlgFormName		: "フォーム名",
DlgFormAction	: "アクション",
DlgFormMethod	: "メソッド",

// Select Field Dialog
DlgSelectName		: "名前",
DlgSelectValue		: "値",
DlgSelectSize		: "サイズ",
DlgSelectLines		: "行",
DlgSelectChkMulti	: "複数項�選択を許可",
DlgSelectOpAvail	: "利用可能なオプション",
DlgSelectOpText		: "選択項�名",
DlgSelectOpValue	: "選択項�値",
DlgSelectBtnAdd		: "追加",
DlgSelectBtnModify	: "編集",
DlgSelectBtnUp		: "上へ",
DlgSelectBtnDown	: "下へ",
DlgSelectBtnSetValue : "選択した値を設�",
DlgSelectBtnDelete	: "削除",

// Textarea Dialog
DlgTextareaName	: "名前",
DlgTextareaCols	: "列",
DlgTextareaRows	: "行",

// Text Field Dialog
DlgTextName			: "名前",
DlgTextValue		: "値",
DlgTextCharWidth	: "サイズ",
DlgTextMaxChars		: "最大長",
DlgTextType			: "タイプ",
DlgTextTypeText		: "テキスト",
DlgTextTypePass		: "パスワード入力",

// Hidden Field Dialog
DlgHiddenName	: "名前",
DlgHiddenValue	: "値",

// Bulleted List Dialog
BulletedListProp	: "�条書き プロパティ",
NumberedListProp	: "�落番号 プロパティ",
DlgLstStart			: "開始文字",
DlgLstType			: "タイプ",
DlgLstTypeCircle	: "白丸",
DlgLstTypeDisc		: "黒丸",
DlgLstTypeSquare	: "四角",
DlgLstTypeNumbers	: "アラビア数字 (1, 2, 3)",
DlgLstTypeLCase		: "英字小文字 (a, b, c)",
DlgLstTypeUCase		: "英字大文字 (A, B, C)",
DlgLstTypeSRoman	: "ローマ数字小文字 (i, ii, iii)",
DlgLstTypeLRoman	: "ローマ数字大文字 (I, II, III)",

// Document Properties Dialog
DlgDocGeneralTab	: "全般",
DlgDocBackTab		: "背景",
DlgDocColorsTab		: "色とマージン",
DlgDocMetaTab		: "メタデータ",

DlgDocPageTitle		: "ページタイトル",
DlgDocLangDir		: "言語文字表記�方向",
DlgDocLangDirLTR	: "左から右に表記(LTR)",
DlgDocLangDirRTL	: "右から左に表記(RTL)",
DlgDocLangCode		: "言語コード",
DlgDocCharSet		: "文字セット符号化",
DlgDocCharSetCE		: "Central European",
DlgDocCharSetCT		: "Chinese Traditional (Big5)",
DlgDocCharSetCR		: "Cyrillic",
DlgDocCharSetGR		: "Greek",
DlgDocCharSetJP		: "Japanese",
DlgDocCharSetKR		: "Korean",
DlgDocCharSetTR		: "Turkish",
DlgDocCharSetUN		: "Unicode (UTF-8)",
DlgDocCharSetWE		: "Western European",
DlgDocCharSetOther	: "他�文字セット符号化",

DlgDocDocType		: "文書タイプヘッダー",
DlgDocDocTypeOther	: "そ�他文書タイプヘッダー",
DlgDocIncXHTML		: "XHTML�言をインクルード",
DlgDocBgColor		: "背景色",
DlgDocBgImage		: "背景画像 URL",
DlgDocBgNoScroll	: "スクロールしない背景",
DlgDocCText			: "テキスト",
DlgDocCLink			: "リンク",
DlgDocCVisited		: "アクセス済みリンク",
DlgDocCActive		: "アクセス中リンク",
DlgDocMargins		: "ページ・マージン",
DlgDocMaTop			: "上部",
DlgDocMaLeft		: "左",
DlgDocMaRight		: "右",
DlgDocMaBottom		: "下部",
DlgDocMeIndex		: "文書�キーワード(カンマ区切り)",
DlgDocMeDescr		: "文書�概要",
DlgDocMeAuthor		: "文書�作者",
DlgDocMeCopy		: "文書�著作権",
DlgDocPreview		: "プレビュー",

// Templates Dialog
Templates			: "テンプレート(雛形)",
DlgTemplatesTitle	: "テンプレート内�",
DlgTemplatesSelMsg	: "エディターで使用するテンプレートを選択してください。<br>(現在�エディタ�内�は失われます):",
DlgTemplatesLoading	: "テンプレート一覧読み込み中. しばらくお待ちください...",
DlgTemplatesNoTpl	: "(テンプレートが�義されていません)",
DlgTemplatesReplace	: "現在�エディタ�内�と�換えをします",

// About Dialog
DlgAboutAboutTab	: "バージョン情報",
DlgAboutBrowserInfoTab	: "ブラウザ情報",
DlgAboutLicenseTab	: "ライセンス",
DlgAboutVersion		: "バージョン",
DlgAboutInfo		: "より詳しい情報はこちらで"
};
