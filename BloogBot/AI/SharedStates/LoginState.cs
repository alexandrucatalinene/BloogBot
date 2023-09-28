﻿using BloogBot.Game;
using System.Collections.Generic;

namespace BloogBot.AI.SharedStates
{
    public class LoginState : BotState, IBotState
    {
        readonly Stack<IBotState> botStates;
        readonly IDependencyContainer container;

        string accountUsername;

        public LoginState(Stack<IBotState> botStates, IDependencyContainer container, string accountName)
        {
            this.botStates = botStates;
            this.container = container;
            this.accountUsername = accountName;
        }
        public void Update()
        {
            if (FrameHelper.IsElementVisibile("CharSelectEnterWorldButton") && Wait.For("CharacterScreenAnim", 1000))
            {
                Functions.LuaCall("CharSelectEnterWorldButton:Click()");
                botStates.Pop();
            }
            else if (FrameHelper.IsElementVisibile("AccountLoginAccountEdit"))
            {
                Functions.LuaCall(
                $"   local username = '{accountUsername}'" +
                "\r\nlocal password = 'password'" +
                "\r\nAccountLoginAccountEdit:SetText(username)" +
                "\r\nAccountLoginPasswordEdit:SetText(password)" +
                "\r\nAccountLogin_Login()");
            }
        }
    }
}
