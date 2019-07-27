using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class DialogViewModelBase : BindableBase, IDialogAware
    {
        private DelegateCommand<string> closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            closeDialogCommand ?? (closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string iconSource;
        public string IconSource
        {
            get { return iconSource; }
            set { SetProperty(ref iconSource, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual void CloseDialog(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
