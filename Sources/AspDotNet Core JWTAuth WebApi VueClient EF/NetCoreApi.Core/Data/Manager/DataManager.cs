using $safeprojectname$.Data.Repositories;

namespace $safeprojectname$.Data.Manager
{
    public partial class DataManager : IDataManager
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ITrackRepository _trackRepository;

        public DataManager()
        {
        }

        public DataManager(IAlbumRepository albumRepository,
            IArtistRepository artistRepository,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IGenreRepository genreRepository,
            IInvoiceLineRepository invoiceLineRepository,
            IInvoiceRepository invoiceRepository,
            IMediaTypeRepository mediaTypeRepository,
            IPlaylistRepository playlistRepository,
            ITrackRepository trackRepository
        )
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _genreRepository = genreRepository;
            _invoiceLineRepository = invoiceLineRepository;
            _invoiceRepository = invoiceRepository;
            _mediaTypeRepository = mediaTypeRepository;
            _playlistRepository = playlistRepository;
            _trackRepository = trackRepository;
        }
    }
}