// libs
import React, { useState } from 'react';
import Tippy from '@tippyjs/react/headless';
import classNames from 'classnames/bind';
import { Wrapper as PopperWrapper } from '~/components/Popper';

// layouts
import styles from './Menu.module.scss';
import MenuItems from './MenuItems';
import Header from './Header';

const cx = classNames.bind(styles);

const defaultFunction = () => {};

const Menu = ({ children, items = [], hideOnClick = false, onChange = defaultFunction, ...passProps }) => {
    // lấy ra trang nhất có nghĩa lấy ra phần tử cuối của mảng
    const [history, setHistory] = useState([{ data: items }]);
    // phần tử hiện tại - phần tử cuối
    const current = history[history.length - 1];

    const renderItems = () => {
        // render current - lay data
        return current.data.map((item, index) => {
            // !! convert boolean -> true false
            const isParent = !!item.children;
            return (
                <MenuItems
                    key={index}
                    data={item}
                    onClick={() => {
                        if (isParent) {
                            // consolelog test
                            //console.log(item.children);
                            setHistory((prev) => [...prev, item.children]);
                        } else {
                            onChange(item);
                        }
                    }}
                />
            );
        });
    };

    return (
        <Tippy
            //visible //nếu chọn visible thì có thể hiện mặc định
            interactive
            delay={[0, 700]}
            offset={[30, 14]} // căn độ lệch cho menu avatar - chieu ngang, chieu cao
            hideOnClick={hideOnClick} // ẩn khi click - ở đây là menu của avtar
            placement="bottom-end"
            render={(attrs) => (
                <div className={cx('menu-list')} tabIndex="-1" {...attrs}>
                    <PopperWrapper className={cx('menu-popper')}>
                        {history.length > 1 && (
                            <Header
                                title="Language"
                                onBack={() => {
                                    // đơn giản là xóa phần tử cuối đi nó sẽ lùi lại 1 cấp
                                    setHistory((prev) => prev.slice(0, prev.length - 1));
                                }}
                            />
                        )}
                        <div className={cx('menu-body')}>{renderItems()}</div>
                    </PopperWrapper>
                </div>
            )}
            // set về phần tử đầu tiên -> khi bỏ hover sẽ trả về
            onHide={() => setHistory((prev) => prev.slice(0, 1))}
        >
            {children}
        </Tippy>
    );
};

export default Menu;
