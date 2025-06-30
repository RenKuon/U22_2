#include <windows.h>		  // windowsAPI用
#include <commdlg.h>		  // ダイアログ作成用
#include <shellscalingapi.h>  // 高DPI対応
#pragma comment(lib, "Shcore.lib")
#include <stdlib.h>
#include <stdio.h>




int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int nCmdShow) {
	// 高DPI対応（Windows 8.1以降）
	SetProcessDpiAwareness(PROCESS_PER_MONITOR_DPI_AWARE);

	// ファイルパス格納用バッファ
	wchar_t filepath[MAX_PATH] = L"";

	// ファイルダイアログの構造体設定
	OPENFILENAMEW ofn = {};						// 構造体の作製　typedef
	ofn.lStructSize = sizeof(ofn);				// 構造体のサイズの指定
	ofn.hwndOwner = NULL;						// 親ウィンドウがない場合は NULL
	ofn.lpstrFilter = L"すべてのファイル\0*.*mp4";// ダイアログで選択できるファイル名、拡張子の設定 ファイル名.txtなど
	ofn.lpstrFile = filepath;					// 取得したファイルパスを入れる変数の指定
	ofn.nMaxFile = MAX_PATH;					// 取得するパスを何文字取得するかの設定
	ofn.Flags = OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST;// ダイアログでファイルを選択するときの設定 存在しているファイルか,正しいパスか
	ofn.lpstrTitle = L"ファイルを選択";			// ダイアログの表示名の設定

	// ダイアログ表示＆ファイルパス取得
	if (GetOpenFileNameW(&ofn)) {
		// ファイルパスを表示


		// MessageBoxW(ハンドル,メッセージ本文,	ダイアログの表示名,ボタンやアイコン)
		MessageBoxW(NULL, filepath, L"選択されたファイルパス", MB_OK | MB_ICONINFORMATION);
	}
	else {
		MessageBoxW(NULL, L"キャンセルまたはエラー", L"通知", MB_OK | MB_ICONWARNING);
	}

	char cut[1024];
	char filepath_c[MAX_PATH];			//wchar型をchar型に変換するための変数

	size_t len = 0;
	wcstombs_s(&len, filepath_c, sizeof(filepath_c), filepath, _TRUNCATE);


	snprintf(cut, sizeof(cut), "ffmpeg -i \"%s\" -ss 00:00:10 -to 00:00:20 -c copy output.mp4", filepath_c);

	system(cut);
	MessageBoxW(NULL, L"完了しました", L"情報", MB_OK);


	return 0;
}