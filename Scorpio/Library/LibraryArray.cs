﻿using System;
using System.Collections.Generic;
using System.Text;
using Scorpio;
namespace Scorpio.Library
{
    public class LibraryArray
    {
        public static ScriptTable Table = new ScriptTable();
        public static void Load(Script script)
        {
            Table.SetValue("count", script.CreateFunction(new count()));
            Table.SetValue("insert", script.CreateFunction(new insert()));
            Table.SetValue("add", script.CreateFunction(new add()));
            script.SetObjectInternal("array", Table);
        }
        private class count : ScorpioHandle
        {
            public object Call(object[] args) {
                return ((ScriptArray)args[0]).Count();
            }
        }
        private class insert : ScorpioHandle
        {
            public object Call(object[] args) {
                ScriptArray array = (ScriptArray)args[0];
                int index = ((ScriptNumber)args[1]).ToInt32();
                ScriptObject obj = (ScriptObject)args[2];
                array.Insert(index, obj);
                return obj;
            }
        }
        private class add : ScorpioHandle
        {
            public object Call(object[] args) {
                ScriptArray array = (ScriptArray)args[0];
                ScriptObject obj = (ScriptObject)args[1];
                array.Add(obj);
                return obj;
            }
        }
    }
}
