import React from "react";
import {IPerson} from './IPerson';

interface ICardProps {
    person: IPerson
}

const Card = (props: ICardProps) => {
    const card = props.person;

    return (
        <p>{card.name}</p>
    );
}

export default Card;
