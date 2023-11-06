// libs
import { React, useState, useEffect, useRef } from 'react';
import classNames from 'classnames/bind';
import HeadlessTippy from '@tippyjs/react/headless';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

// components
import styles from './Search.module.scss';
import { faCircleXmark, faMagnifyingGlass, faSpinner } from '@fortawesome/free-solid-svg-icons';
import { Wrapper as PopperWrapper } from '~/components/Popper';
import AccountItem from '~/components/AccountItem';
import 'tippy.js/dist/tippy.css'; // optional - cho việc hiển thị tooltip
import { SearchIcon } from '~/components/Icons';
import { useDebounce } from '~/hooks';

const cx = classNames.bind(styles);

const Search = () => {
    const [searchValue, setSearchValue] = useState('');
    const [searchResult, setSearchResult] = useState([]);
    // show khu vuực kết quả Search lên với 2 ddkien, có ký tự và phải đc focus
    const [showResult, setShowResult] = useState(true);
    const [loading, setLoading] = useState(false);

    // 1: '' lần đầu tiên component này chạy là 1 chuỗi rỗng
    // 2: 'h'
    const debounced = useDebounce(searchValue, 500);

    const inputRef = useRef();

    // get api
    useEffect(() => {
        if (!debounced.trim()) {
            setSearchResult([]);
            return;
        }

        setLoading(true);

        fetch(`https://tiktok.fullstack.edu.vn/api/users/search?q=${encodeURIComponent(debounced)}&type=less`)
            .then((res) => res.json())
            .then((res) => {
                setSearchResult(res.data);
                setLoading(false);
            })
            .catch(() => {
                setLoading(false);
            });
    }, [debounced]);

    const handleClear = () => {
        // text input
        setSearchValue('');
        // kết quả tìm kiếm get từ api -> thay thế thành mảng rỗng
        setSearchResult([]);
        inputRef.current.focus(); // mục đích giữ nguyên kết quả cũ trong khi vẫn có thể focus(dấu nháy active nhập text của thanh search) vào nó
    };

    // ẩn danh sách kết quả tìm kiếm khi không focus
    const handleHideResult = () => {
        setShowResult(false);
    };

    return (
        // Tippy: hỗ trợ hiển thị hiển thị khung list khi hover - tooltip
        <HeadlessTippy
            // điều kiện để hiển thị danh sách kết quả tìm kiếm searchResult.length > 0
            interactive
            visible={showResult && searchResult.length > 0}
            render={(attrs) => (
                <PopperWrapper>
                    <div className={cx('search-result')} tabIndex="-1" {...attrs}>
                        <h4 className={cx('search-title')}>Accounts</h4>
                        {searchResult.map((result) => (
                            <AccountItem key={result.id} data={result} />
                        ))}
                    </div>
                </PopperWrapper>
            )}
            // đọc doc của Tippy
            // onclickOutSide: bấm ra ngoài khu vực Tippy
            onClickOutside={handleHideResult}
        >
            <div className={cx('search')}>
                <input
                    ref={inputRef} //?
                    value={searchValue}
                    placeholder="Search courses and blogs"
                    spellCheck={false}
                    onChange={(e) => setSearchValue(e.target.value)}
                    onFocus={() => setShowResult(true)}
                />
                {/* khi có searchValue thì hiển thị button clear */}
                {!!searchValue && !loading && (
                    //button clear -> x
                    <button className={cx('clear')} onClick={handleClear}>
                        <FontAwesomeIcon icon={faCircleXmark} />
                    </button>
                )}

                {/* button loading */}
                {loading && <FontAwesomeIcon className={cx('loading')} icon={faSpinner} />}

                {/* button search */}
                <button className={cx('search-btn')}>
                    <SearchIcon />
                </button>
            </div>
        </HeadlessTippy>
    );
};

export default Search;
