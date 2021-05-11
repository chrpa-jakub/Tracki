--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 13.2

-- Started on 2021-05-11 09:44:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 16417)
-- Name: accountTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."accountTypes" (
    "typeID" integer NOT NULL,
    "typeName" text NOT NULL
);


ALTER TABLE public."accountTypes" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16433)
-- Name: artists; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.artists (
    "artistID" integer NOT NULL,
    "artistName" text,
    "artistLocation" text,
    "userID" integer NOT NULL
);


ALTER TABLE public.artists OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 16490)
-- Name: photos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.photos (
    "photoID" integer NOT NULL,
    location text
);


ALTER TABLE public.photos OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 16475)
-- Name: releaseTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."releaseTypes" (
    "releaseTypeID" integer NOT NULL,
    "releaseTypeName" text NOT NULL
);


ALTER TABLE public."releaseTypes" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16447)
-- Name: releases; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.releases (
    "releaseID" integer NOT NULL,
    "albumName" text NOT NULL,
    "artistID" integer NOT NULL,
    "yearOfRelease" integer NOT NULL,
    "releaseTypeID" integer NOT NULL,
    "photoID" integer
);


ALTER TABLE public.releases OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 16461)
-- Name: songs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.songs (
    "songID" integer NOT NULL,
    "songName" text NOT NULL,
    "releaseID" integer NOT NULL,
    "songLocation" text NOT NULL
);


ALTER TABLE public.songs OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16395)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    "userID" integer NOT NULL,
    "userName" text,
    "accountTypeID" integer NOT NULL,
    "passwordHash" text,
    "photoID" integer
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16408)
-- Name: users_accountTypeID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.users ALTER COLUMN "accountTypeID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."users_accountTypeID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 201 (class 1259 OID 16398)
-- Name: users_userID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.users ALTER COLUMN "userID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."users_userID_seq"
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3044 (class 0 OID 16417)
-- Dependencies: 203
-- Data for Name: accountTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."accountTypes" ("typeID", "typeName") FROM stdin;
\.


--
-- TOC entry 3045 (class 0 OID 16433)
-- Dependencies: 204
-- Data for Name: artists; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.artists ("artistID", "artistName", "artistLocation", "userID") FROM stdin;
\.


--
-- TOC entry 3049 (class 0 OID 16490)
-- Dependencies: 208
-- Data for Name: photos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.photos ("photoID", location) FROM stdin;
\.


--
-- TOC entry 3048 (class 0 OID 16475)
-- Dependencies: 207
-- Data for Name: releaseTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."releaseTypes" ("releaseTypeID", "releaseTypeName") FROM stdin;
\.


--
-- TOC entry 3046 (class 0 OID 16447)
-- Dependencies: 205
-- Data for Name: releases; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.releases ("releaseID", "albumName", "artistID", "yearOfRelease", "releaseTypeID", "photoID") FROM stdin;
\.


--
-- TOC entry 3047 (class 0 OID 16461)
-- Dependencies: 206
-- Data for Name: songs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.songs ("songID", "songName", "releaseID", "songLocation") FROM stdin;
\.


--
-- TOC entry 3041 (class 0 OID 16395)
-- Dependencies: 200
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users ("userID", "userName", "accountTypeID", "passwordHash", "photoID") FROM stdin;
\.


--
-- TOC entry 3055 (class 0 OID 0)
-- Dependencies: 202
-- Name: users_accountTypeID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."users_accountTypeID_seq"', 1, false);


--
-- TOC entry 3056 (class 0 OID 0)
-- Dependencies: 201
-- Name: users_userID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."users_userID_seq"', 0, false);


--
-- TOC entry 2888 (class 2606 OID 16424)
-- Name: accountTypes accountTypes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."accountTypes"
    ADD CONSTRAINT "accountTypes_pkey" PRIMARY KEY ("typeID");


--
-- TOC entry 2893 (class 2606 OID 16454)
-- Name: releases albums_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.releases
    ADD CONSTRAINT albums_pkey PRIMARY KEY ("releaseID");


--
-- TOC entry 2890 (class 2606 OID 16440)
-- Name: artists artists_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.artists
    ADD CONSTRAINT artists_pkey PRIMARY KEY ("artistID");


--
-- TOC entry 2903 (class 2606 OID 16497)
-- Name: photos photos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.photos
    ADD CONSTRAINT photos_pkey PRIMARY KEY ("photoID");


--
-- TOC entry 2901 (class 2606 OID 16482)
-- Name: releaseTypes releaseTypes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."releaseTypes"
    ADD CONSTRAINT "releaseTypes_pkey" PRIMARY KEY ("releaseTypeID");


--
-- TOC entry 2899 (class 2606 OID 16468)
-- Name: songs songs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.songs
    ADD CONSTRAINT songs_pkey PRIMARY KEY ("songID");


--
-- TOC entry 2886 (class 2606 OID 16426)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY ("userID");


--
-- TOC entry 2883 (class 1259 OID 16520)
-- Name: fki_FK_PhotoIDUser; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_PhotoIDUser" ON public.users USING btree ("photoID");


--
-- TOC entry 2884 (class 1259 OID 16432)
-- Name: fki_FK_accountTypeID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_accountTypeID" ON public.users USING btree ("accountTypeID");


--
-- TOC entry 2897 (class 1259 OID 16474)
-- Name: fki_FK_albumID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_albumID" ON public.songs USING btree ("releaseID");


--
-- TOC entry 2894 (class 1259 OID 16460)
-- Name: fki_FK_artistID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_artistID" ON public.releases USING btree ("artistID");


--
-- TOC entry 2895 (class 1259 OID 16488)
-- Name: fki_FK_releaseTypeID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_releaseTypeID" ON public.releases USING btree ("releaseTypeID");


--
-- TOC entry 2891 (class 1259 OID 16446)
-- Name: fki_FK_userID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_userID" ON public.artists USING btree ("userID");


--
-- TOC entry 2896 (class 1259 OID 16526)
-- Name: fki_Fk_PhotoIDRelease; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Fk_PhotoIDRelease" ON public.releases USING btree ("photoID");


--
-- TOC entry 2905 (class 2606 OID 16515)
-- Name: users FK_PhotoIDUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "FK_PhotoIDUser" FOREIGN KEY ("photoID") REFERENCES public.photos("photoID") NOT VALID;


--
-- TOC entry 2904 (class 2606 OID 16427)
-- Name: users FK_accountTypeID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "FK_accountTypeID" FOREIGN KEY ("accountTypeID") REFERENCES public."accountTypes"("typeID") NOT VALID;


--
-- TOC entry 2907 (class 2606 OID 16455)
-- Name: releases FK_artistID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.releases
    ADD CONSTRAINT "FK_artistID" FOREIGN KEY ("artistID") REFERENCES public.artists("artistID") NOT VALID;


--
-- TOC entry 2910 (class 2606 OID 16469)
-- Name: songs FK_releaseID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.songs
    ADD CONSTRAINT "FK_releaseID" FOREIGN KEY ("releaseID") REFERENCES public.releases("releaseID") NOT VALID;


--
-- TOC entry 2908 (class 2606 OID 16483)
-- Name: releases FK_releaseTypeID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.releases
    ADD CONSTRAINT "FK_releaseTypeID" FOREIGN KEY ("releaseTypeID") REFERENCES public."releaseTypes"("releaseTypeID") NOT VALID;


--
-- TOC entry 2906 (class 2606 OID 16441)
-- Name: artists FK_userID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.artists
    ADD CONSTRAINT "FK_userID" FOREIGN KEY ("userID") REFERENCES public.users("userID") NOT VALID;


--
-- TOC entry 2909 (class 2606 OID 16521)
-- Name: releases Fk_PhotoIDRelease; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.releases
    ADD CONSTRAINT "Fk_PhotoIDRelease" FOREIGN KEY ("photoID") REFERENCES public.photos("photoID") NOT VALID;


-- Completed on 2021-05-11 09:44:42

--
-- PostgreSQL database dump complete
--

