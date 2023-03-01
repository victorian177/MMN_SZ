
// AiRepeat.h : PROJECT_NAME アプリケーションのメイン ヘッダー ファイルです。
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH に対してこのファイルをインクルードする前に 'stdafx.h' をインクルードしてください"
#endif

#include "resource.h"		// メイン シンボル


// CAiRepeatApp:
// このクラスの実装については、AiRepeat.cpp を参照してください。
//

class CAiRepeatApp : public CWinApp
{
public:
	CAiRepeatApp();

// オーバーライド
public:
	virtual BOOL InitInstance();

// 実装

	DECLARE_MESSAGE_MAP()
};

extern CAiRepeatApp theApp;