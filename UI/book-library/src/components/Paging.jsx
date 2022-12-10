const PagingNumbers = ({size, onClick}) => 
    [...Array(size)].map((_, i) =>
        <button className="pagination-number" onClick={() => onClick(i)}>
            { i + 1 }
        </button>)


export const Paging = ({totalCount, pageSize, onClick}) => {
    const size = Math.ceil(totalCount / pageSize);

    if(size)
    {
        return (
            <nav className="pagination-container">
                <PagingNumbers size={size} onClick={onClick} />
            </nav>
        )
    }
}

export default Paging;