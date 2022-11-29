﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;
using VirindiViewService;
using VirindiViewService.Controls;

namespace AceCreator
{
    public partial class AceCreator : PluginBase
    {

        
        public HudCombo ChoiceLandblockJSON { get; set; }
        public HudButton ButtonImportLandblockJSON { get; set; }
        public HudButton ButtonEditLandblockJSON { get; set; }

        public HudCombo ChoiceLandblockSQL { get; set; }
        public HudButton ButtonImportLandblockSQL { get; set; }
        public HudButton ButtonEditLandblockSQL { get; set; }

        public HudButton ButtonReloadLandblock { get; set; }
        public HudButton ButtonClearCache { get; set; }

        public HudButton ButtonGetCurrentLandblock { get; set; }
        public HudButton ButtonExportLandblock { get; set; }

        public HudTextBox TextboxCurrentLandblock { get; set; }
        public HudButton CommandRefreshLBFilesList { get; set; }

        // Button Events
        public void ButtonImportLandblockJSON_Click(object sender, EventArgs e)
        {
            try
            {
                string wcid = ((HudStaticText)ChoiceLandblockJSON[ChoiceLandblockJSON.Current]).Text.Replace(".json", "");
                Util.SendChatCommand(@"/import-json " + wcid + " landblock");
            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        public void ButtonImportLandblockSQL_Click(object sender, EventArgs e)
        {
            try
            {
                string wcid = ((HudStaticText)ChoiceLandblockSQL[ChoiceLandblockSQL.Current]).Text.Replace(".sql", "");
                Util.SendChatCommand(@"/import-sql " + wcid + " landblock");
            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        public void ButtonEditLandblockJSON_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(Globals.PathLandBlockJSON + @"\" + ((HudStaticText)ChoiceLandblockJSON[ChoiceLandblockJSON.Current]).Text);
            }
            catch (Exception ex) { Util.LogError(ex); }

        }
        public void ButtonEditLandblockSQL_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(Globals.PathLandBlockSQL + @"\" + ((HudStaticText)ChoiceLandblockSQL[ChoiceLandblockSQL.Current]).Text);
            }
            catch (Exception ex) { Util.LogError(ex); }

        }

        public void ButtonReloadLandblock_Click(object sender, EventArgs e)
        {

            try
            {
                Util.SendChatCommand("/reload-landblock");
            }
            catch (Exception ex) { Util.LogError(ex); }

        }
        public void ButtonClearCache_Click(object sender, EventArgs e)
        {

            try
            {
                Util.SendChatCommand("/clearcache");
            }
            catch (Exception ex) { Util.LogError(ex); }

        }

        public void ButtonGetCurrentLandblock_Click(object sender, EventArgs e)
        {
            Globals.ButtonCommand = "GetLandblock";
            try
            {
                Util.SendChatCommand("/myloc");
            }
            catch (Exception ex) { Util.LogError(ex); }

        }
        public void ButtonExportLandblock_Click(object sender, EventArgs e)
        {
            
            try
            {
                Util.SendChatCommand("/export-sql landblock " + TextboxCurrentLandblock.Text);
            }
            catch (Exception ex) { Util.LogError(ex); }
            LoadLandBlockJSONChoiceList();
            LoadLandBlockSQLChoiceList();
        }
        public void ButtonRefreshLBFilesList_Click(object sender, EventArgs e)
        {
            try
            {
                Util.WriteToChat("Reloading FileLists");
                RefreshAllLists();

                // Util.WriteToChat("Text= " + ((HudStaticText)ChoiceSQL[ChoiceSQL.Current]).Text);
            }
            catch (Exception ex) { Util.LogError(ex); }
        }
    }
}
