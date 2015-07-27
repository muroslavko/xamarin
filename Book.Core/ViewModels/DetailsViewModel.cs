using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;
using System.Runtime.CompilerServices;

namespace Books.Core.ViewModels
{
    /// <summary>
    /// TODO implement Details view model to download and hold detail information about the book
    /// Also you need to implement views for each platform for this model
    /// </summary>
    public class DetailsViewModel 
        : MvxViewModel
    {
        private readonly IBooksService _books;

        public DetailsViewModel(IBooksService books)
        {
            _books = books;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            // TODO get and cast incomming bundle to the parameter passed from FirstViewModel
            // details here
            // https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation

            base.InitFromBundle(parameters);
        }
        [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
        public void Init(string id)
        {
            Update(id);
        }

        private void Update(string id)
        {
            _books.SelectAsync(id,
                result => Info = result,
                error => { });
        }
        private BookSearchItem _info;
        public BookSearchItem Info
        {
            get { return _info; }
            set { _info = value; RaisePropertyChanged(() => Info); }
        }
    }
}
