# 록끼끼 - 벽돌깨기
![image](/Image/TitleImage.png)
> 내일배움 캠프 Unity 6기 유니티 입문주차 프로젝트  
> 2024.10.15 ~ 2024.10.22
### 맴버 및 역할 분담
- 장병래 (팀장)
    - 사용자 입력
- 박수연
    - UI 및 아이템, 동적 생성
- 백승우
    - ball 및 사운드
- 성기혁
    - 벽돌 및 아이템
- 홍신영
    - 게임 로직 및 점수

## 게임 소개
- 원숭이가 돌로 바나나가 갇힌 벽돌을 깨 바나나를 먹는 벽돌깨기 게임
### 조작 방법
- 좌우 이동 : A D
### 아이템
![image](/BreakOutProject/Assets/Resources/Sprites/longPaddle.png)  
패들이 길어지는 아이템  
![image](/BreakOutProject/Assets/Resources/Sprites/multiBall.png)  
공이 여러개 생기는 아이템  
![image](/BreakOutProject/Assets/Resources/Sprites/screenControl.png)  
화면을 가리는 아이템  
![image](/BreakOutProject/Assets/Resources/Sprites/timeControl.png)  
시간이 빨라지거나 느려지는 아이템  

## 구현 상세
### 사용 에셋
- sprite : chat gpt의 Dall-e 모델 사용
- background :
    - https://assetstore.unity.com/packages/2d/environments/2d-pixel-art-platformer-biome-american-forest-255694
    - https://assetstore.unity.com/packages/2d/environments/2d-pixel-art-platformer-biome-american-forest-255694
- sound : https://pixabay.com/ko/sound-effects/
### 기술
- 사용자 입력
    - New Input system 활용
- Ball
    - reflection vector을 활용하여 튕겨져 나가는 물리 구현
- 벽돌 및 아이템
    - 생성 및 파괴의 최적화를 위해 object pooling 기법 활용
- 아이템
    - 확장성을 위해 커멘드 패턴을 활용
- 점수
    - 게임이 종료되도 점수가 저장되도록 json직렬화를 활용해 점수를 저장
- UI
    - popup을 매번 intantiate하지 않기 위해 cache dic을 만들어 한번 생성한 popup은 껐다 켰다 할 수 있도록 함.


 
