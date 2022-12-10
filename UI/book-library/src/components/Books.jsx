import React from "react";
import Select from 'react-select'
import { BOOK_PAGE_SIZE } from "../constants";
import styles from "../styles/app.module.css";
import Paging from './Paging'
import useFilter  from '../Api'

let [searchKey, searchValue] = [];

const Books = () => {
    const [books, totalCount, filterBooks] = useFilter();

    const onPageClick = (pageIndex) => {
        filterBooks(searchKey, searchValue, pageIndex)
    }

    const handleSubmit = event => {
        event.preventDefault();

        searchKey = event.target.searchKey.value;
        searchValue = event.target.searchValue.value;

        filterBooks(searchKey, searchValue);
    }
    
    return (
    <>
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>Search By:</td>
                        <td><Select name='searchKey' options={[
                            { value: 'title', label: 'Title '},
                            { value: 'publisher', label: 'Publisher '},
                            { value: 'author', label: 'Author' },
                            { value: 'type', label: 'Type' },
                            { value: 'isbn', label: 'ISBN' },
                            { value: 'category', label: 'Category'}
                        ]} /></td>
                    </tr>
                    <tr>
                        <td>Search Value:</td>
                        <td><input name='searchValue' /></td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td><input type="submit" value="Search"/></td>
                    </tr>
                </tfoot>
            </table>
        </form>

        <table className={styles.bookTable}>
            <thead className={styles.bookHeader}>
                <tr>
                    <th>Book Title</th>
                    <th>Publisher</th>
                    <th>Authors</th>
                    <th>Type</th>
                    <th>ISBN</th>
                    <th>Category</th>
                    <th>Available Copies</th>
                </tr>
            </thead>
            <tbody>
                {books && books.map((el) => (
                    <tr key={el.id}>
                        <td>{el.title}</td>
                        <td>{el.publisher}</td>
                        <td>{el.authors}</td>
                        <td>{el.type}</td>
                        <td>{el.isbn}</td>
                        <td>{el.category}</td>
                        <td>{`${el.availableCopies}/${el.allCopies}`}</td>
                    </tr>
                ))}
            </tbody>
            <tfoot>
                <tr>
                    <td><Paging totalCount={totalCount} pageSize={BOOK_PAGE_SIZE} onClick={(i) => onPageClick(i)} /></td>
                </tr>
            </tfoot>
      </table>
    </>);
}

export default Books;