#include <windows.h>		  // windowsAPI�p
#include <commdlg.h>		  // �_�C�A���O�쐬�p
#include <shellscalingapi.h>  // ��DPI�Ή�
#pragma comment(lib, "Shcore.lib")
#include <stdlib.h>
#include <stdio.h>




int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int nCmdShow) {
	// ��DPI�Ή��iWindows 8.1�ȍ~�j
	SetProcessDpiAwareness(PROCESS_PER_MONITOR_DPI_AWARE);

	// �t�@�C���p�X�i�[�p�o�b�t�@
	wchar_t filepath[MAX_PATH] = L"";

	// �t�@�C���_�C�A���O�̍\���̐ݒ�
	OPENFILENAMEW ofn = {};						// �\���̂̍쐻�@typedef
	ofn.lStructSize = sizeof(ofn);				// �\���̂̃T�C�Y�̎w��
	ofn.hwndOwner = NULL;						// �e�E�B���h�E���Ȃ��ꍇ�� NULL
	ofn.lpstrFilter = L"���ׂẴt�@�C��\0*.*mp4";// �_�C�A���O�őI���ł���t�@�C�����A�g���q�̐ݒ� �t�@�C����.txt�Ȃ�
	ofn.lpstrFile = filepath;					// �擾�����t�@�C���p�X������ϐ��̎w��
	ofn.nMaxFile = MAX_PATH;					// �擾����p�X���������擾���邩�̐ݒ�
	ofn.Flags = OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST;// �_�C�A���O�Ńt�@�C����I������Ƃ��̐ݒ� ���݂��Ă���t�@�C����,�������p�X��
	ofn.lpstrTitle = L"�t�@�C����I��";			// �_�C�A���O�̕\�����̐ݒ�

	// �_�C�A���O�\�����t�@�C���p�X�擾
	if (GetOpenFileNameW(&ofn)) {
		// �t�@�C���p�X��\��


		// MessageBoxW(�n���h��,���b�Z�[�W�{��,	�_�C�A���O�̕\����,�{�^����A�C�R��)
		MessageBoxW(NULL, filepath, L"�I�����ꂽ�t�@�C���p�X", MB_OK | MB_ICONINFORMATION);
	}
	else {
		MessageBoxW(NULL, L"�L�����Z���܂��̓G���[", L"�ʒm", MB_OK | MB_ICONWARNING);
	}

	char cut[1024];
	char filepath_c[MAX_PATH];			//wchar�^��char�^�ɕϊ����邽�߂̕ϐ�

	size_t len = 0;
	wcstombs_s(&len, filepath_c, sizeof(filepath_c), filepath, _TRUNCATE);


	snprintf(cut, sizeof(cut), "ffmpeg -i \"%s\" -ss 00:00:10 -to 00:00:20 -c copy output.mp4", filepath_c);

	system(cut);
	MessageBoxW(NULL, L"�������܂���", L"���", MB_OK);


	return 0;
}