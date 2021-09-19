import React from "react";
import {IFilm} from '../../interfaces/IFilm';

interface IFilmProps {
    film: IFilm;
}

const Film = (props: IFilmProps) => {
    const film = props.film;

    return (
        <div>
            <div>{film.title}</div>
            <div>{film.release_date}</div>
            <div>{film.opening_crawl}</div>
        </div>
    )
}

export default Film;