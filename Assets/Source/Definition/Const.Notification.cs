using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Notification
    {
<<<<<<< HEAD
        public const string UPDATE_QUEST_INFO = "QrScanLogin";
=======
        #region Http request
        public const string QR_SCAN_LOGIN = "QrScanLogin";
>>>>>>> ce45d319df79ad068327896bd1cba6022d682fdf
        public const string LOGIN_SUCCESS = "LoginSuccess";
        public const string LOGIN_FAIL = "LoginFail";
        public const string LOGOUT = "Logout";
        public const string LOGOUT_SUCCESS = "LogoutSuccess";
        public const string CHECK_LOGIN_STATUS = "CheckLoginStatus";
        public const string CHECK_USER_INFO_EXIST = "CheckUserInfo";
        public const string SUBMIT_USER_INFO = "SubmitUserInfo";
        #endregion

        #region Local system
        public const string LOAD_UI_FORM = "LoadUIForm";
        public const string LOAD_UI_ROOT_FORM = "LoadUIRootForm";
        public const string BACK_TO_LAST_FORM = "BackToLastForm";
        public const string GO_TO_HOME_FORM = "GoToHomeForm";
        public const string GAME_STARTED = "GameStarted";
        public const string LOAD_SCENE = "LoadScene";
        #endregion

<<<<<<< HEAD
        public const string CHECK_USER_INFO_EXIST = "CheckUserInfo";
        public const string SUBMIT_USER_INFO = "SubmitUserInfo";

        public const string UPDATE_QUEST_INFO_TASK = "TravelTaskInfo";
        public const string UPDATE_HINT_TEXT = "TravelHintText";
        //old, cc code ood 
        public const string SEND_LOGIN = "SendLogin";
=======
        #region Communication
        public const string WS_SEND = "WsSend";
>>>>>>> ce45d319df79ad068327896bd1cba6022d682fdf
        public const string CONNECT_TO_WS_SERVER = "ConnectToWsServer";
        public const string SETUP_CONNECTION_WITH_SERVER = "SetupConnectionWithServer";
        #endregion
    }
}
