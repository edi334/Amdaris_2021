import {IFilm} from './IFilm';

export interface IPerson {
    name: string;
    height: string;
    mass: string;
    hair_color: string;
    skin_color: string;
    eye_color: string;
    films: IFilm[];
}