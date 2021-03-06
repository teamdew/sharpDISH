﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DISH
{
    public class DISH : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new DISH());
        }

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public DISH()
        {
            // Create a simple tray menu with only one item.
            createMenu();

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "MyTrayApp";

            trayIcon.Icon = new Icon("Resources/pepper-icon.ico");

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }

        private void createMenu()
        {
            trayMenu = new ContextMenu();

            MenuItem urlSubmenu = new MenuItem();
            urlSubmenu.Text = "URL";
            trayMenu.MenuItems.Add(urlSubmenu);
                urlSubmenu.MenuItems.Add("Change URL", OnExit);
                urlSubmenu.MenuItems.Add("Clear Cache", OnExit);

            MenuItem tempSubmenu = new MenuItem();
            tempSubmenu.Text = "HOSTS FILE HERE";
            trayMenu.MenuItems.Add(tempSubmenu);
                tempSubmenu.MenuItems.Add("Open Putty", OnExit);
                tempSubmenu.MenuItems.Add("View Community Log", OnExit);
            
            trayMenu.MenuItems.Add("Make Spice Admin", OnExit);
            trayMenu.MenuItems.Add("View Production Log", OnExit);

            MenuItem hostFileOptionsSubmenu = new MenuItem();
            hostFileOptionsSubmenu.Text = "Hosts File";
            trayMenu.MenuItems.Add(hostFileOptionsSubmenu);
                hostFileOptionsSubmenu.MenuItems.Add("Edit hosts file", OnExit);
                hostFileOptionsSubmenu.MenuItems.Add("New hosts file", OnExit);
                hostFileOptionsSubmenu.MenuItems.Add("Open hosts file directory", OnExit);

            trayMenu.MenuItems.Add("Message", OnExit);
            trayMenu.MenuItems.Add("RELEASE DATA");
            trayMenu.MenuItems.Add("Release", OnExit);
            trayMenu.MenuItems.Add("Settings", OnExit);
            trayMenu.MenuItems.Add("Quit", OnExit);
        }
    }
}

