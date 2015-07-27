using System.Collections.Generic;
using System.Windows.Input;
using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;
using System;

namespace Books.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        public string Hello { get { return "Hello MvvmCross"; } }
        private readonly IBooksService _books;

        public FirstViewModel(IBooksService books)
        {
            _books = books;
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; RaisePropertyChanged(() => SearchTerm); Update();
            }
        }

        private List<BookSearchItem> _results;
        public List<BookSearchItem> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
        }

        private void Update()
        {
            _books.StartSearchAsync(SearchTerm,
                result => Results = result.items,
                error => {});
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand
        {
            get
            {
                _goToDetailsCommand = new DelegateCommand<string>(showDetails);
                // TODO create a command that will navigate to details screen
                // it should be invoked on list item click
                // it should accept book id or url so that details screen can fetch additional info
                return _goToDetailsCommand;
            }
        }

        private void showDetails(string id)
        {
            ShowViewModel<DetailsViewModel>(new {id = id }); // pass "reference to the book" here
        }

    }

    public class DelegateCommand<T> : ICommand
    {

        private Action<string> ExecuteAction { get; set; }

        public event EventHandler CanExecuteChanged;

        public DelegateCommand
          (
          Action<string> executeAction
          )
        {
            ExecuteAction = executeAction;
        }

        public bool CanExecute
          (
          object parameter
          )
        {
            return true;
        }

        public void Execute
          (
          object parameter
          )
        {
            ExecuteAction(Convert.ToString(parameter));
        }

    }
}
