// libs
import React, { useEffect, useState } from 'react';
import classNames from 'classnames/bind';
import Tippy from '@tippyjs/react/headless';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

// components
import styles from './Header.module.scss';
import images from '~/assets/images';
import {
    faCircleXmark,
    faMagnifyingGlass,
    faSpinner,
    faEarthAsia,
    faCircleQuestion,
    faKeyboard,
    faEllipsisVertical,
} from '@fortawesome/free-solid-svg-icons';
import { Wrapper as PopperWrapper } from '~/components/Popper';
import AccountItem from '~/components/AccountItem';
import Button from '~/components/Button';
import Menu from '~/components/Popper/Menu';

const cx = classNames.bind(styles);

const MENU_ITEMS = [
    {
        icon: <FontAwesomeIcon icon={faEarthAsia} />,
        tilte: 'English',
    },
    {
        icon: <FontAwesomeIcon icon={faCircleQuestion} />,
        tilte: 'learningpaths',
        to: '/learningpaths',
    },
    {
        icon: <FontAwesomeIcon icon={faKeyboard} />,
        tilte: 'longtesttesttesttest',
    },
];

const Header = () => {
    const [searchResult, setSearchResult] = useState([]);

    useEffect(() => {
        setTimeout(() => {
            // để hiển thị ra popper các accountitems
            //setSearchResult([1, 2, 3]);
            setSearchResult([]);
        }, 0);
    }, []);

    return (
        <header className={cx('wrapper')}>
            <div className={cx('inner')}>
                <div className={cx('logo')}>
                    <img src={images.logo} alt="OLS" />
                </div>
                {/* search */}
                {/* Tippy: hỗ trợ hiển thị hiển thị khung list khi hover - tooltip */}
                <Tippy
                    // điều kiện để hiển thị danh sách kết quả tìm kiếm
                    visible={searchResult.length > 0}
                    interactive={true}
                    render={(attrs) => (
                        <PopperWrapper>
                            <div className={cx('search-result')} tabIndex="-1" {...attrs}>
                                <h4 className={cx('search-title')}>Accounts</h4>
                                <AccountItem />
                                <AccountItem />
                                <AccountItem />
                            </div>
                        </PopperWrapper>
                    )}
                >
                    <div className={cx('search')}>
                        <input placeholder="Search courses and blogs" spellCheck={false} />
                        {/* button clear -> x */}
                        <button className={cx('clear')}>
                            <FontAwesomeIcon icon={faCircleXmark} />
                        </button>
                        {/* button loading */}
                        <button className={cx('loading')}>
                            <FontAwesomeIcon icon={faSpinner} />
                        </button>
                        {/* button search */}
                        <button className={cx('search-btn')}>
                            <FontAwesomeIcon icon={faMagnifyingGlass} />
                        </button>
                    </div>
                </Tippy>

                {/* Actions */}
                <div className={cx('actions')}>
                    {/* Register */}
                    <Button text>Register</Button>

                    {/* Login */}
                    <Button primary>Login</Button>

                    {/* nút ... dọc*/}
                    <Menu items={MENU_ITEMS}>
                        <button className={cx('more-btn')}>
                            <FontAwesomeIcon icon={faEllipsisVertical} />
                        </button>
                    </Menu>
                </div>
            </div>
        </header>
    );
};

export default Header;
