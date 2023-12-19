// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

// components
import styles from './CourseInProgress.module.scss';
import { faBars, faArrowRight, faPen, faTrash, faX } from '@fortawesome/free-solid-svg-icons';
import { faComment } from '@fortawesome/free-regular-svg-icons';
import Image from '~/components/Image';

const cx = classNames.bind(styles);

const CourseInProgress = () => {
    const [chapters, setChapters] = useState([]);
    const [lessons, setLessons] = useState([]);
    const [loading, setLoading] = useState(true);
    const [activeChapter, setActiveChapter] = useState(null);
    const [courseDetails, setCourseDetails] = useState('');
    const [lessonDetails, setLessonDetails] = useState('');
    const [showDiscuss, setShowDiscuss] = useState(false);
    const [showNote, setShowNote] = useState(false);

    // Toggle
    const [clickCount, setClickCount] = useState(1);

    const handleToggleMenu = () => {
        setClickCount(clickCount + 1);
    };
    const cx = classNames.bind(styles);

    // Extracting courseId from the URL
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get('courseId');
    const lessonId = urlParams.get('lessonId');

    useEffect(() => {
        const fetchDataFromApi = async () => {
            try {
                const responseChapters = await axios.get(`https://localhost:7158/getAllChaptersByCourseId/${courseId}`);
                setChapters(responseChapters.data);
            } catch (error) {
                console.error('Error fetching course:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchDataFromApi();
    }, [courseId]); // Add courseId to the dependency array

    // Use useEffect to fetch lessons when activeChapter changes
    useEffect(() => {
        const fetchLessonsByChapterId = async () => {
            try {
                if (activeChapter !== null) {
                    const responseLessons = await axios.get(
                        `https://localhost:7158/getAllLessonsByChapterId/${activeChapter}`,
                    );
                    setLessons(responseLessons.data);
                }
            } catch (error) {
                console.error('Error fetching lessons:', error);
            }
        };

        fetchLessonsByChapterId();
    }, [activeChapter]); // Run this effect whenever activeChapter changes

    useEffect(() => {
        const fetchCourseDetailsFromCourseId = async () => {
            try {
                const responseCourse = await axios.get(`https://localhost:7158/getCourseByCourseId_Home/${courseId}`);
                setCourseDetails(responseCourse.data); // Corrected function name
            } catch (error) {
                console.error('Error fetching course:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchCourseDetailsFromCourseId();
    }, [lessonId]);

    useEffect(() => {
        const fetchLessonDetailsFromLessonId = async () => {
            try {
                const responseLesson = await axios.get(`https://localhost:7158/getLessonById/${lessonId}`);
                setLessonDetails(responseLesson.data); // Corrected function name
            } catch (error) {
                console.error('Error fetching lesson:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchLessonDetailsFromLessonId();
    }, [lessonId]); // Add courseId to the dependency array

    if (loading) {
        return <div>Loading...</div>; // You can replace this with a loading spinner or message
    }

    // Function to toggle active chapter
    const handleToggleChapter = (chapterId) => {
        setActiveChapter((prev) => (prev === chapterId ? null : chapterId));
    };

    // Function to toggle discuss section visibility
    const handleToggleDiscuss = () => {
        setShowDiscuss((prevShowDiscuss) => !prevShowDiscuss);
    };

    const handleToggleNote = () => {
        setShowNote((prevShowNote) => !prevShowNote);
    };

    return (
        <main className={cx('wrapper')}>
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('side-bar-wrap')}>
                            <div className={cx('action-wrap')}>
                                <div className={cx('action-menu')} onClick={handleToggleMenu}>
                                    <FontAwesomeIcon icon={faBars} /> <span>Menu</span>
                                </div>

                                <div className={cx('action-next')}>
                                    <span>Next</span> <FontAwesomeIcon icon={faArrowRight} />
                                </div>
                            </div>
                            <nav
                                className={cx('side-bar', {
                                    'menu-open': clickCount % 2 === 1,
                                    'menu-close': clickCount % 2 === 0,
                                })}
                            >
                                <ul className={cx('chapter-list')}>
                                    <h1 className={cx('chapter-list__name')}>Chapters</h1>
                                    {chapters.map((chapter) => (
                                        <li
                                            key={chapter.chapterId}
                                            className={cx(
                                                `lesson-item ${activeChapter === chapter.chapterId ? 'active' : ''}`,
                                            )}
                                            onClick={() => handleToggleChapter(chapter.chapterId)}
                                        >
                                            <p className={cx('chapter-item__name')}>{chapter.chapterName}</p>
                                            {activeChapter === chapter.chapterId && (
                                                <div className={cx('lesson-item__wrap')}>
                                                    {lessons.map((lesson) => (
                                                        <span key={lesson.lessonId} className={cx('lesson-item__name')}>
                                                            {/* <Link
                                                                to={`http://localhost:3003/course-in-progress?courseId=${courseId}&lessonId=${lesson.lessonId}`}
                                                                onClick={() => handleToggleChapter(chapter.chapterId)}
                                                            >
                                                                <p>{lesson.title}</p>
                                                            </Link> */}

                                                            <a
                                                                href={`http://localhost:3003/course-in-progress?courseId=${courseId}&lessonId=${lesson.lessonId}`}
                                                                onClick={(e) => {
                                                                    handleToggleChapter(chapter.chapterId);
                                                                    window.location.href = `http://localhost:3003/course-in-progress?courseId=${courseId}&lessonId=${lesson.lessonId}`;
                                                                }}
                                                            >
                                                                <p>{lesson.title}</p>
                                                            </a>
                                                        </span>
                                                    ))}
                                                </div>
                                            )}
                                        </li>
                                    ))}
                                </ul>
                            </nav>
                        </div>

                        <section className={cx('content', { 'menu-close': clickCount % 2 === 0 })}>
                            <div className={cx('course-lesson')}>
                                {lessonDetails && lessonDetails.video ? (
                                    <iframe
                                        className={cx('course-lesson__video')}
                                        src={lessonDetails.video}
                                        frameBorder="0"
                                        allowFullScreen
                                    ></iframe>
                                ) : (
                                    <img
                                        className={cx('course-lesson__video')}
                                        src={courseDetails.image}
                                        frameBorder="0"
                                        allowFullScreen
                                    ></img>
                                )}

                                <div className={cx('course-lesson__name-notes-wrap')}>
                                    {lessonDetails && lessonDetails.video ? (
                                        <span className={cx('course-lesson__name-title')}>{lessonDetails.title}</span>
                                    ) : (
                                        <span className={cx('course-lesson__name-title')}>
                                            {courseDetails.courseName}
                                        </span>
                                    )}

                                    <span className={cx('course-lesson__note-title')} onClick={handleToggleNote}>
                                        <FontAwesomeIcon icon={faPen} /> Save notes
                                    </span>
                                </div>
                            </div>
                        </section>

                        <div className={cx('discuss')} style={{ display: showDiscuss ? 'block' : 'none' }}>
                            <div className={cx('discuss-content-wrap')}>
                                <div className={cx('discuss-heading')}>
                                    <span className={cx('discuss-heading__count')}>309 asks and replies</span>
                                </div>
                                <div className={cx('discuss-input')}>
                                    <Image
                                        src={'https://avatars.githubusercontent.com/u/108357953?v=4'}
                                        className={cx('user-avatar')}
                                    />
                                    <input
                                        type="text"
                                        placeholder={'Ask here'}
                                        className={cx('discuss-input__user-input')}
                                    />
                                    <input
                                        type="file"
                                        accept="image/*"
                                        className={cx('discuss-input__user-input-image')}
                                    />
                                </div>
                                <div className={cx('discuss-ask-reply')}>
                                    <div className={cx('discuss-ask')}>
                                        <div className={cx('discuss-ask__image')}>
                                            <Image
                                                src={'https://avatars.githubusercontent.com/u/108357953?v=4'}
                                                className={cx('user-avatar')}
                                            />
                                        </div>
                                        <div className={cx('discuss-ask__wrap')}>
                                            <span className={cx('user-name')}>Bui Van Kien</span>
                                            <div className={cx('discuss-ask-content__wrap')}>
                                                <Image
                                                    src={'https://s.net.vn/oa2E'}
                                                    className={cx('discuss-ask-content__image')}
                                                />
                                                <p className={cx('discuss-ask-content__detail')}>
                                                    Topic sentences are similar to mini thesis statements. Like a thesis
                                                    statement, a topic sentence has a specific main point. Whereas the
                                                    thesis is the main point of the essay, the topic sentence is the
                                                    main point of the paragraph. Like the thesis statement, a topic
                                                    sentence has a unifying function. But a thesis statement or topic
                                                    sentence alone doesn’t guarantee unity. An essay is unified if all
                                                    the paragraphs relate to the thesis, whereas a paragraph is unified
                                                    if all the sentences relate to the topic sentence. Note: Not all
                                                    paragraphs need topic sentences. In particular, opening and closing
                                                    paragraphs, which serve different functions from body paragraphs,
                                                    generally don’t have topic sentences.
                                                </p>
                                            </div>
                                            <p className={cx('discuss-ask__reply-title')}>Trả lời</p>
                                        </div>
                                    </div>
                                    <div className={cx('discuss-reply')}>
                                        <div className={cx('discuss-reply__input-wrap')}>
                                            <Image
                                                src={'https://avatars.githubusercontent.com/u/108357953?v=4'}
                                                className={cx('user-avatar')}
                                            />
                                            <input
                                                type="text"
                                                placeholder="reply here"
                                                className={cx('discuss-reply__input')}
                                            />
                                            <input
                                                type="file"
                                                accept="image/*"
                                                className={cx('discuss-reply__input-image')}
                                            />
                                        </div>
                                        <div className={cx('discuss-reply__content-wrap')}>
                                            <div className={cx('discuss-reply__image')}>
                                                <Image
                                                    src={
                                                        'https://people.com/thmb/pX_6cwzhf7ofzK7SiAewtmcKvhc=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(646x129:648x131)/dog-born-with-crooked-face-112823-1-e303fbe5c5674ae28b69ab3521bb64c2.jpg'
                                                    }
                                                    className={cx('user-avatar')}
                                                />
                                            </div>
                                            <div className={cx('discuss-reply__list')}>
                                                <span className={cx('user-name')}>Nguyen Van A</span>
                                                <p className={cx('discuss-reply__item')}>
                                                    <span className={cx('discuss-reply__user-tag')}>Bui Van Kien </span>
                                                    This topic sentence forecasts the central idea or main point of the
                                                    paragraph: “politicians” and “journalists” rely on Twitter. The rest
                                                    of the paragraph will focus on these two Twitter-user groups,
                                                    thereby fulfilling the promise made by the topic sentence. By
                                                    avoiding irrelevant information that does not relate to the topic
                                                    sentence, you can compose a unified paragraph.
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className={cx('course-discuss')} onClick={handleToggleDiscuss}>
                            <FontAwesomeIcon icon={faComment} />
                        </div>

                        <div className={cx('note')} style={{ display: showNote ? 'block' : 'none' }}>
                            <div className={cx('note-wrap')}>
                                <span className={cx('note-close')} onClick={handleToggleNote}>
                                    <FontAwesomeIcon icon={faX} />
                                </span>
                                <div className={cx('note-heading')}>
                                    <span className={cx('note-heading__title')}>Them ghi chu</span>
                                </div>
                                <div className={cx('note-content')}>
                                    <input
                                        type="text"
                                        placeholder="Noi dung ghi chu..."
                                        className={cx('note-content__input')}
                                    />
                                </div>
                                <div className={cx('note-content-list')}>
                                    <span className={cx('note-content-list__title')}>Danh sach ghi chu</span>
                                    <div className={cx('note-content-list__wrap')}>
                                        <br />
                                        <p className={cx('note-content-list__item')}>+ Ghi chu thu nhat</p>
                                        <div className={cx('note-content-list__item-icon')}>
                                            <p className={cx('note-content-list__item-icon__edit')}>
                                                <FontAwesomeIcon icon={faPen} />
                                            </p>
                                            <p className={cx('note-content-list__item-icon__delete')}>
                                                <FontAwesomeIcon icon={faTrash} />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    );
};

export default CourseInProgress;
