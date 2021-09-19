import React from 'react';

interface SearchBarProps {
    keyword: string;
    setKeyword: (input: string) => Promise<void>;
}

const SearchBar = ({keyword, setKeyword}: SearchBarProps) => {
    return (
        <input 
        key="key"
        value={keyword}
        placeholder={"search country"}
        onChange={(e) => setKeyword(e.target.value)}
        />
    );
}

export default SearchBar