import React, {useEffect, useState} from "react";
import {useLocation} from "react-router-dom";
import {IFilm} from '../interfaces/IFilm';
import axios from "axios";
import Film from './components/film';

const Films = () => {
    const location: any = useLocation();
    const filmUrls: string[] = location.state.films;
    const [films, setFilms] = useState<IFilm[]>([]);

    useEffect(() => {
        const prevFilms: IFilm[] = [];
        filmUrls.forEach(f => {
            axios.get<IFilm>(f).then(film => {
                prevFilms.push(film.data);
            });
        });
        console.log(prevFilms);
        console.log('wadw');
        setFilms(prevFilms);
        console.log(films);
        
    }, [filmUrls])

    return (
        films.length ? <div>
            {
                 films.map((film, index) => (
                    <Film key={index} film={film}/>
                ))
            }
        </div> : <div>Waiting...</div>
    );
}

export default Films;