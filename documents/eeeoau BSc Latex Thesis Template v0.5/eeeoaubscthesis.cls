
% This template is distributed with ABSOLUTELY NO WARRANTY.
% It serves as a guideline and constitutes a basic structure for a
% thesis/dissertation. The user assumes full responsibility for formatting
% and typesetting their document and for verifying that all the thesis
% requirements set by the University of Tennessee are met. Please refer to the most
% recent UT thesis guide (http://web.utk.edu/~thesis/thesisresources.shtml)
% or contact the thesis consultant (http://web.utk.edu/~thesis/).
% Please report any bugs to the thesis consultant.


\NeedsTeXFormat{LaTeX2e}%
\def\filename{utthesis.cls}%
\def\fileversion{ver 1.0.0}%
\def\filedate{March 30, 2010}%
\def\contributors{Tony Saad, Uwa Obayiuwana, Kayode Ayodele}%
\typeout{\filename}%
\typeout{\fileversion}%
\typeout{Created by Tony Saad}%
\typeout{\filedate}%
\typeout{Some parts and settings of this class are based on the template provided by David L. Page.}
%---------------------------------------------------------------------------------------------------%
\ProvidesClass{eeeoaubscthesis}
% some internal variables
\def\thesisID{1}%
\def\dissertationID{2}%
\def\theDocumentType#1{\gdef\@theDocumentType{#1}}%
\def\documentID#1{\gdef\@documentID{#1}}% documentID is either 1 (for thesis) or 2 (for dissertation)
% declare package options
\DeclareOption{thesis}{%
    \def\@theDocumentType{thesis}%
    \def\@documentID{\thesisID}}%
\DeclareOption{dissertation}{%
    \def\@theDocumentType{dissertation}%
    \def\@documentID{\dissertationID}}%
\DeclareOption{linespacing}{\@lnspacing}
\DeclareOption*{\PassOptionsToPackage{\CurrentOption}{color}}%
\DeclareOption*{\PassOptionsToClass{\CurrentOption}{report}}%
\ExecuteOptions{dissertation,a4paper,12pt}% execute default options
\ProcessOptions%
\LoadClass{report} % single-sided


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 	Main Definitions
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\def\copyrightYear#1{\gdef\@copyrightYear{#1}}%
\def\graduationMonth#1{\gdef\@graduationMonth{#1}}%
\def\majorProfessor#1{\gdef\@majorProfessor{#1}}%
\def\keywords#1{\gdef\@keywords{#1}}%
\def\major#1{\gdef\@major{#1}}%
\def\degree#1{\gdef\@degree{#1}}%
\def\college#1{\gdef\@college{#1}}%
\def\dept#1{\gdef\@dept{#1}}%
\def\university#1{\gdef\@university{#1}}%
\def\supervisor#1 {\gdef\@supervisor{#1}}% first supervisor
\def\cosupervisor#1 {\gdef\@cosupervisor{#1}}% second supervisor
\def\supervisorDept#1 {\gdef\@supervisorDept{#1}}% first supervisor
\def\cosupervisorDept#1 {\gdef\@cosupervisorDept{#1}}% second supervisor
\def\thesisyear#1{\gdef\@thesisyear{#1}}%
\def\regnumber#1{\gdef\@regnumber{#1}}%
\def\authorsurname#1{\gdef\@authorsurname{#1}}%
\def\authorothernames#1{\gdef\@authorothernames{#1}}%
%\def\numberOfSupervisors#1{\gdef\@numberOfSupervisors{#1}}%

% initialize macros
\def\@title{My Title}
\def\@authorsurname{Surname}
\def\@authorothernames{Other Names}
\def\@regnumber{TP07/08/3232}
\def\@keywords{My Keywords}
\def\@graduationMonth{December}
\def\@degree{BACHELOR}
\def\@supervisor{----}
\def\@cosupervisor{----}
\def\@supervisorDept{----}
\def\@cosupervisorDept{----}
\def\@thesisyear{----}
%\def\@numberOfSupervisors{1}

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 	LOAD PACKAGES
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\RequirePackage{amsmath,amsthm,amssymb}     % AMS math, AMS theorem, AMS fonts
\RequirePackage{setspace}                   % line spacing
\RequirePackage[vcentering,dvips]{geometry}	% help with margins
\RequirePackage[pdftex,plainpages=false,pdfpagelabels=true,breaklinks=true]{hyperref} % for pdf bookmarks
\RequirePackage{color}
%----------------------------------------------------------------------------------------------------%
% define theorem, corollary, and lemma environments
\theoremstyle{plain}
\newtheorem*{theorem*}{Theorem}
\newtheorem{theorem}{Theorem}[chapter]
\newtheorem{corollary}{Corollary}[theorem]
\newtheorem{lemma}{Lemma}[theorem]
%----------------------------------------------------------------------------------------------------%
% allow empty pages before chapters (i.e. no page numbers)
\let\origdoublepage\cleardoublepage
\newcommand{\clearemptydoublepage}{%
  \clearpage
  {\pagestyle{empty}\origdoublepage}%
}
\let\cleardoublepage\clearemptydoublepage
%----------------------------------------------------------------------------------------------------%
\hypersetup{%
	bookmarksnumbered = true,
	pdftitle={\@title},
	pdfauthor={\@authorsurname},
	pdfsubject={\@keywords},
	pdfkeywords={\@keywords},
	pdfpagelayout=SinglePage,
    bookmarksopen=False,
	%pdfview=FitV,
	pdfborder=0 0 0, 		% make all links invisible, so the pdf looks good when printed	
    pdffitwindow=true,      % window fit to page when opened
    %pdfstartview={FitV},   % fits the width of the page to the window
    pdfcreator={\@author},  % creator of the document
    pdfnewwindow=true,      % links in new window
    colorlinks=true,        % false: boxed links; true: colored links
    linkcolor=blue,         % color of internal links
    citecolor=blue,      % color of links to bibliography
    filecolor=magenta,      % color of file links
    urlcolor=cyan           % color of external links
}
%----------------------------------------------------------------------------------------------------%
\geometry{
    a4paper,
    left = 1.0in,          % 1.5in
    right = 1.0in,        % 1.0in
    top = 1.0in,           % 1.0in  
    bottom = 1.20in      % 1.375in
}

%\hyphenation{example, pa-ra-me-ter} % Over-ride Latex hyphenation, define hyphenated words
\hyphenpenalty=5000	% reduce hyphenation as much as possible
\tolerance=1000     % goes with the previous command
% Widow/orphan protection
\clubpenalty=10000    % Minimize orphans orphans(eliminate 10000)
\widowpenalty=10000   % Minimize widows
\brokenpenalty=10000  % Do not allow hyphen across pages
% Use cool footnotes
\renewcommand{\thefootnote}{\fnsymbol{footnote}}
\raggedbottom
\pagestyle{plain}


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% makeTitlePage
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\makeTitlePage} { 
	\thispagestyle{empty}

    \begin{spacing}{1}
	\vspace*{0.15in}
	\begin{center}
		\large\MakeUppercase{\textbf{\@title}}%
	\end{center}
	\end{spacing}
	\begin{spacing}{1.2}
	\begin{center}
	\vspace*{0.15 in}
		\Large \rm
		{\sc by}\\
		\vspace*{0.25 in}
		\@authorsurname\hspace{7pt}\@authorothernames\\
		(\@regnumber)

\vspace{1.5 cm}
    \includegraphics[scale=0.16]{oaulogo} \\  
\vspace{1.5cm}

        \vfill


        \small
        A THESIS SUBMITTED IN PARTIAL FULFILMENT OF THE\\
        REQUIREMENTS FOR THE AWARD OF BACHELOR OF SCIENCE IN\\
        ELECTRONIC AND ELECTRICAL ENGINEERING\\
        \vspace*{0.3in}
        FACULTY OF TECHNOLOGY\\
        OBAFEMI AWOLOWO UNIVERSITY\\
        ILE-IFE, NIGERIA\\
        \vspace*{0.6in}
        \@graduationMonth \small{ }  \@thesisyear

	\end{center}
    \end{spacing}
    \cleardoublepage
}



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%		makeAuthorizationPage : this macro will make the Authorization page
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\makeAuthorizationPage} {
	\thispagestyle{empty}
	
	\begin{spacing}{1.5}
		\newpage
		\chapter*{ \textbf{\Large \sc Authorization to Copy}}
		\vspace{50pt}
		\centerline {\textbf {\large OBAFEMI AWOLOWO UNIVERSITY, ILE-IFE}}
		\centerline {\textbf {\large HEZEKIAH OLUWASANMI LIBRARY}}
		\centerline {\textbf {\large UNDERGRADUATE  THESIS}}
		\vspace{50pt}
		
		\begin{hangparas}{1.25in}{1}
		AUTHOR:   
		\hspace{7pt}
		\MakeUppercase{\@authorsurname}\hspace{5pt}\@authorothernames
		\end{hangparas}

		\begin{hangparas}{1in}{1}
			TITLE:\hspace{30pt}\@title
		\end{hangparas}	
		
		DEGREE:\hspace{18pt}B.Sc. (Electronic and Electrical Engineering) \\  
		YEAR:\hspace{35pt}\@thesisyear
		\vspace{30pt}
	
		\begin{hangparas}{1pt}{1}	
			I, \MakeUppercase{\@authorsurname} \@authorothernames, hereby authorize the Hezekiah Oluwasanmi Library to copy my thesis, in whole or part, in response to request from individual researchers and Organizations for the purpose of private studies or research.		
		
			\vspace{50pt}
		
			Signature:\underline{\hspace{2.5in}}  
			\hspace{25pt}
			Date:\underline{\hspace{2in}}  
		\end{hangparas}	

	\end{spacing}
	\pagebreak%
}


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%		makeCertificationPage: this macro will make the certification page
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand {\makeCertificationPage}[1]{
	\thispagestyle{empty}
	\begin{spacing}{1.2}
		
		\chapter*{\textbf{\Large \sc Certification}}
		\vspace{50pt}
		
		\ifthenelse{\equal{#1}{1}}
		{I}% #1 = #2 -> [#1]
		{We}% [#1,#2]	
		\hspace{10pt}certify that this work was carried out by \MakeUppercase{\@authorsurname} \@authorothernames  \textbf{ }in partial fulfilment of the requirements for the award of the degree of Bachelor of Science (B.Sc.), in the Department of Electronic and Electrical Engineering, Obafemi Awolowo University, Ile-Ife, Nigeria.
		
		\vspace{70pt}
		\centerline{------------------------------------------------}				
		\centerline{\textbf{\@supervisor}}		
		\centerline{\@supervisorDept}		
		\centerline{Obafemi Awolowo University, Ile-Ife}

		\ifthenelse{\equal{#1}{1}}	%if there are two supervisors, also create details of the co-super
		{}
		{\addCosupervisor}% [#1,#2]

	\end{spacing}
	\pagebreak%
}

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\addSupervisorSignature}[2]{
	\vspace*{.3in}%
	\newline%
	\underline{\hspace*{2.5in}}%
	\\[8pt]%
	\noindent #1%
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\addCommitteeMember}[1] {
	\vspace*{.3in}%
    \newline%
	\underline{\hspace*{2.5in}}%
	\\[8pt]%
	\noindent #1%
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\addCosupervisor}{
		\vspace{70pt}
		\centerline{------------------------------------------------}		
		\newline
		\centerline{\textbf{\@cosupervisor}}
		\newline
		\centerline{\@cosupervisorDept}
		\newline
		\centerline{Obafemi Awolowo University, Ile-Ife}
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\makeAppendixPage}{
    \newpage
    \vspace*{2.0in}
    \begin{center}\Huge \bf{Appendix} \end{center}
    \newpage
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand{\makeReferencesPage}{
    \newpage % create a new page for the Reference title
    \addToTOC{References} % add References to table of contents
    \vspace*{2.0in} % move down the page 2.0 inches
    \begin{center}\Huge\bf{References}\end{center} % make the References title
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% addToTOC: macro that adds an entry to the table of contents
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand {\addToTOC}[1] {
	\cleardoublepage
	\phantomsection
	\addcontentsline{toc}{chapter}{#1}
}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% addToPDFBookmarks: macro that adds a bookmark to the PDF file
%                   without including it in the table of contents
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\newcommand {\addToPDFBookmarks}[3] {
	\cleardoublepage
	\phantomsection
	\pdfbookmark[#1]{#2}{#3}
}

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
\endinput 
