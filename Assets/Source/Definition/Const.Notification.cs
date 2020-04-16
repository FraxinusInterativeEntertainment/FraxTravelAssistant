using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Notification
    {
        #region Http request
        public const string QR_SCAN_LOGIN = "QrScanLogin";
        public const string LOGIN_SUCCESS = "LoginSuccess";
        public const string LOGIN_FAIL = "LoginFail";
        public const string LOGOUT = "Logout";
        public const string LOGOUT_SUCCESS = "LogoutSuccess";
        public const string CHECK_LOGIN_STATUS = "CheckLoginStatus";
        public const string CHECK_USER_INFO_EXIST = "CheckUserInfo";
        public const string EDIT_USER_USER_INFO = "EditUserInfo";
        public const string BACK_EXTRA_USER_INFO = "UserExtraInfo";
        public const string SUBMIT_USER_INFO = "SubmitUserInfo";
        public const string UPDATE_QUEST_INFO_TASK = "TravelTaskInfo";
        public const string REQUEST_HINT_INFO = "RequestHintInfo";
        public const string SEND_HINT_NAME = "SendHintName"; 
        public const string UPDATE_HINT_TEXT = "TravelHintText";
        public const string BACK_HINT_INFO = "BackHintInfo";
        public const string UPDATE_EMAIL_NUMBER = "WikiNumber";
        public const string GET_EMAIL_NUM = "GetEmailNumber";
        public const string GET_WIKI_GROUP_INFO = "GetWikiGroupInfo";
        public const string GET_WIKI_RECORD_INFO = "GetWikiRecordInfo";
        public const string RECEIVE_WIKI_RECORD_INFO = "ReceiveWikiRecordName";

        public const string GET_AREA_LOCK_WIKI_GROUP_INFO = "GetAreaLockWikiGroupInfo";
        public const string GET_FORCE_LOCK_WIKI_GROUP_INFO = "GetForceLockWikiGroupInfo";
        public const string BACK_AVAILABLE_AREA_WIKI_GROUP_INFO = "BackAvailableaAreaWikiGroup";
        public const string BACK_AVAILABLE_FORCE_WIKI_GROUP_INFO = "BackAvailableaForceWikiGroup";
        public const string SEND_WIKI_GROUP_NAME = "SendWikiGroupName";
        public const string GET_WIKI_GROUP_BACKGROUND_STORY = "GetWikiGroupBackStory";
        public const string BACK_BACKGROUND_STORY="BackGroundStory";
        public const string GET_WIKI_RECORD_STORY = "GetWikiRecordStory";
        public const string BACK_WIKI_RECORD_STORY = "BackWikiRecordStory";
        #endregion

        #region Local system
        public const string LOAD_UI_FORM = "LoadUIForm";
        public const string LOAD_UI_ROOT_FORM = "LoadUIRootForm";
        public const string BACK_TO_LAST_FORM = "BackToLastForm";
        public const string GO_TO_HOME_FORM = "GoToHomeForm";
        public const string GAME_STARTED = "GameStarted";
        public const string LOAD_SCENE = "LoadScene";
        #endregion

        #region Communication
        public const string WS_SEND = "WsSend";

        public const string GET_ACTOR_INFO = "GetActorInfo";
        public const string SET_ACTOR_ID = "SetActorId";
        public const string SHOW_ACTOR_INFO = "ShowActorInfo";
        public const string GAME_CLOSED = "GAME_CLOSED";

        //old, cc code ood 
        public const string SEND_LOGIN = "SendLogin";
        public const string CONNECT_TO_WS_SERVER = "ConnectToWsServer";
        public const string SETUP_CONNECTION_WITH_SERVER = "SetupConnectionWithServer";
        #endregion
    }
}
