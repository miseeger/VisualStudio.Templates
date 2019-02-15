import Axios from 'axios';

export async function getAlbumById(id: number) {
    return await Axios.get(`http://localhost:4746/api/Album/${id}`);
}

