﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SeliseFileExplorer.Constants;
using SeliseFileExplorer.Model;

namespace SeliseFileExplorer.ViewModel
{
    public class FolderDetailsViewModel : ViewModelBase
    {
        public List<Folder> Folders { get; set; }

        public List<File> Files { get; set; }

        public ObservableCollection<FolderViewModel> ViewList { get; set; }

        public FolderDetailsViewModel()
        {
            MessengerInstance.Register<DirectoryInfo>(this, MessageToken.FolderDetailsViewModel, x => SetValue(x));
        }

        private void SetValue(DirectoryInfo o)
        {
            Folders = o.Folders;
            Files = o.Files;
        }

        public void Initialize()
        {
            ViewList = new ObservableCollection<FolderViewModel>();

            Folders.ForEach(x => ViewList.Add(new FolderViewModel
            {
                Name = x.Name,
                Size = x.Size,
                ModifiedOn = x.ModifiedOn,
                Type = x.Type
            }));

            Files.ForEach(x => ViewList.Add(new FolderViewModel
            {
                Name = x.Name,
                Size = x.Size,
                ModifiedOn = x.ModifiedOn,
                Type = x.Type
            }));
        }

        public void Delete()
        {
            // delete selected files
        }
    }

    public class DirectoryInfo
    {
        public List<Folder> Folders { get; set; }
        public List<File> Files { get; set; }
    }
}